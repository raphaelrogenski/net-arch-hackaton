namespace NetArchHackaton.Shared.Application.Menu.Exceptions
{
    public class MenuItemNotFoundException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Menu Item Not Found!";

        public MenuItemNotFoundException() 
            : base(Message)
        {
        }
    }
}
