//entry_level


namespace PageElements
{
    public class LevelPageLocators
    {
        public string LevelInput = "entry_level";    

        public string SubmitLevel="//*[@class='btn btn-default']";  

        public string AddNewLevel="//*[contains(text(),'Add new')]";

        public string LevelList="//*[@class='panel-title']";

        public string LevelData="//*[@class='table table-striped']/tbody/tr/td";

        public string DeleteLevel="(//*[@class='table table-striped']/tbody/tr/td)[2]/a";
    }
}