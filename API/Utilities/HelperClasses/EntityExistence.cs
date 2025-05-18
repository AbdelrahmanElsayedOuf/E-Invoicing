using Models.Interfaces;

namespace Amazon_Tours.Utilities.HelperClasses
{
    public class EntityExistence
    {
        public IEntity Entity { get; set; }
        public bool IsExisted { get; set; }//
    }
}
