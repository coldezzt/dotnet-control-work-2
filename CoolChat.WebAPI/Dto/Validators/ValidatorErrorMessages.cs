namespace CoolChat.WebAPI.Dto.Validators;

public static class ValidatorErrorMessages
{
    public static string NullOrEmpty() => "Поле не может быть пусто";

    public static string StringLengthShouldBeLessThan(int value) => $"Количество символов должно быть меньше чем {value}";

    public static string StringLengthShouldBeBiggerThan(int value) => $"Количество символов должно быть больше чем {value}";
}