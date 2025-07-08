namespace ToDoList.Api.Utilities
{
    public static class Responses
    {
        public static ResultViewModel ApplicationErrorMessage(string? message)
        {
            return new ResultViewModel(
                Message: message ?? "Ocorreu algum erro interno na aplicação, por favor, tente novamente.", 
                Success: false,
                Data: null);
        }

        public static ResultViewModel DomainErroMessage(string message, IReadOnlyCollection<string>? errors)
        {
            return new ResultViewModel(
                Message: message, 
                Success: false, 
                Data: errors ?? null);
        }

        public static ResultViewModel UnautorizedErrorMessage()
        {
            return new ResultViewModel (
                Message: "Você não tem permissão para acessar este recurso!", 
                Success: false, 
                Data: null);
        }

        public static ResultViewModel SuccessMessage(string message, dynamic? data = null)
        {
            return new ResultViewModel(
                Message: message, 
                Success: true, 
                Data: data);
        }
    }
}
