
using E_Invoicing.Application.DTOs.ReadDTOs;
using E_Invoicing.Application.Interfaces.Identity;
using E_Invoicing.Application.Interfaces.JWT;
using E_Invoicing.Application.Interfaces.Services;
using E_Invoicing.Application.Interfaces.Services.Base;
using E_Invoicing.Application.Interfaces.UnitOfWork;
using E_Invoicing.Application.Services;
using E_Invoicing.Application.Services.Base;
using E_Invoicing.Application.Utilities.JWT;
using E_Invoicing.Infrastructure.UnitOfWork;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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
                options.UseSqlServer(builder.Configuration.GetConnectionString("EInvoicingDBLocal"))
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });

            // Add Identity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => {
                options.Password.RequireDigit = true;           
                options.Password.RequiredLength = 6;            
                options.Password.RequireLowercase = false;      
                options.Password.RequireUppercase = false;      
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 1;       
            })
                .AddEntityFrameworkStores<EInvocingDBContext>()
                .AddDefaultTokenProviders();


            builder.Configuration.AddEnvironmentVariables();
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

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocal5500", builder => builder
                    .WithOrigins("http://localhost:5500")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                );
            });

            var jwtSettings = builder.Configuration.GetSection("JWT");

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        //ValidateIssuer = true,
                        //ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidAudience = jwtSettings["Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SigningKey"])),
                    };
                });

            builder.Services.Configure<JwtSettings>(
                builder.Configuration.GetSection("JWT"));



            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<ICityService, CityService>();
            builder.Services.AddScoped<IClientService, ClientService>();
            builder.Services.AddScoped<ICountryService, CountryService>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IInquiryService, InquiryService>();
            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<ITripService, TripService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IReceiptVoucherService, ReceiptVoucherService>();
            builder.Services.AddScoped<IJwtService, JwtService>();





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

            app.UseCors("AllowLocal5500");
            //app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
