namespace GameZone.ViewModels
{
    public class RoleFormViewModel
    {
        [Required, StringLength(30)]
        public string Name { get; set; } = string.Empty;
    }
}
