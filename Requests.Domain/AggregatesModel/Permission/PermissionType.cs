using Request.Domain.SeedWork;

namespace Request.Domain.AggregatesModel.Permission
{
    public class PermissionType : Entity
    {
        private string _description;

        #region Getters & Setters

        public string Descripcion => _description;

        #endregion Getters & Setters

        protected PermissionType() { }

        public PermissionType(string description)
        {
            _description = description;
        }
    }
}
