public class WarehouseModel
{

    public Int64 ProductId { get; set; }
    public Int64 AmountAvailable { get; set; }



    public WarehouseModel(){}


    public WarehouseModel(Int64 amountavailable)
    {
        AmountAvailable = amountavailable;
    }

}



