namespace Labb2WebbTemplate.App.Models;

public class CartProductModel
{
    public Func<int, int, Task>? AmountHasChanged;
    
    private int _amount;
    
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; }

    public int Amount
    {
        get => _amount;
        set
        {
            _amount = value;
            AmountHasChanged?.Invoke(Id, Amount);
            
        }
    }
}