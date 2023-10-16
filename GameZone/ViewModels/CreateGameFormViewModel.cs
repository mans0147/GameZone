namespace GameZone.ViewModels
{
    public class CreateGameFormViewModel : GameFormViewModel
    {

        [AllowedExtensions(FileSettings.AllowedExtensions),
            MaxFileSise(FileSettings.MaxFileSizebytes)]
        public IFormFile Cover { get; set; } = default!;
    }
}
