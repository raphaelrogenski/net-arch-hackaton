namespace NetArchHackaton.Shared.Application.Menu.Exceptions
{
    public class MenuItemNameAlreadyExistsException : Base.Exceptions.ApplicationException
    {
        private const string Message = "Menu Item Name Already Exists!";

        public MenuItemNameAlreadyExistsException() 
            : base(Message)
        {
        }
    }
}
