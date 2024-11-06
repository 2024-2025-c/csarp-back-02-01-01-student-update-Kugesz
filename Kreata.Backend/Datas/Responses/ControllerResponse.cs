using Kreata.Backend.Datas.Responses;

public class ControllerResponse : ErrorStore
{
    public bool IsSuccess => !HasError;
}