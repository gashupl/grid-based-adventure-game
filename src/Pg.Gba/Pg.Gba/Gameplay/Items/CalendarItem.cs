namespace Pg.Gba.Gameplay.Items
{
    internal class CalendarItem : Item
    {
        public CalendarItem()
        {
            this.Name = "Calendar Item";
            this.Label = "Calendar";
            this.Description = "A calendar showing the current month and year.";
            this.ImagePath = "img/items/calendar_item";
        }
    }
}
