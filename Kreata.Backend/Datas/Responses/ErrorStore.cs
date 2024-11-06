namespace Kreata.Backend.Datas.Responses;

public class ErrorStore
{
    private string _errorMessages;

    public string ErrorMessages
    {
        get => _errorMessages;
        private set => _errorMessages = value;
    }

    public bool HasError => !string.IsNullOrEmpty(_errorMessages);

    public void AddError(string error)
    {
        if (string.IsNullOrEmpty(_errorMessages))
        {
            _errorMessages = error;
        }
        else
        {
            _errorMessages += "\n" + error;
        }
    }
}