namespace GameZone.Setting
{
    public static class FileSettings
    {
        public const string ImagePath = "/assets/images/games";
        public const string AllowedExtensions = ".jpg,.jpeg,.png";
        public const int MaxFileSizeMB = 1;
        public const int MaxFileSizebytes = MaxFileSizeMB * 1024 * 1024;
    }
}
