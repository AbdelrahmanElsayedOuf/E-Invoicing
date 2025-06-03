
using AmazonTours.Application.DTOs.ReadDTOs;
using AmazonTours.Application.Interfaces.Identity;
using AmazonTours.Application.Interfaces.Services;
using AmazonTours.Application.Interfaces.Services.Base;
using AmazonTours.Application.Interfaces.UnitOfWork;
using AmazonTours.Application.Services;
using AmazonTours.Application.Services.Base;
using AmazonTours.Infrastructure.UnitOfWork;
using AutoMapper;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Amazon_Tours
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<EInvocingDBContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("AmazonToursDBLocal"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            // Add Identity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Password.RequireDigit = true;           // Require at least one digit
                options.Password.RequiredLength = 6;            // Set your minimum length
                options.Password.RequireLowercase = false;      // No lowercase required
                options.Password.RequireUppercase = false;      // No uppercase required
                options.Password.RequireNonAlphanumeric = false;// No special characters required
                options.Password.RequiredUniqueChars = 1;       // Only needs one unique char (can be the same digit)
            })
                .AddEntityFrameworkStores<EInvocingDBContext>()
                .AddDefaultTokenProviders();

            // Add Authentication
            // It defines the mechanism through which the application verifies the identity of users or clients.
            builder.Services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                };
            });

            var emailSettings = builder.Configuration.GetSection("EmailSettings");

            builder.Services
                .AddFluentEmail(emailSettings["Email"])
                .AddSmtpSender(() => new SmtpClient(emailSettings["Host"])
                {
                    Port = emailSettings.GetValue<int>("Port"),
                    Credentials = new NetworkCredential(
                        emailSettings["Email"],
                        emailSettings["Password"]
                    ),
                    EnableSsl = true
                });


            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            //builder.Services.AddAutoMapper(typeof(ReceiptVoucherService).Assembly);
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IInquiryService, InquiryService>();
            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<ITripService, TripService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IReceiptVoucherService, ReceiptVoucherService>();




            builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
