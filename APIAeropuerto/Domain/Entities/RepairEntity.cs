using APIAeropuerto.Domain.Shared;

namespace APIAeropuerto.Domain.Entities;

public class RepairEntity
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    public string Comment { get; set; }
    public float Cost { get; set; }
    public DateTime DateInit { get; set; }
    public DateTime DateEnd { get; set; }
    public DateTime DateEstimated { get; set; }
    public Guid IdService { get; set; }
    public ServicesEntity Service { get; set; }
    public Guid IdShip { get; set; }
    public ShipEntity Ship { get; set; }
    
    public RepairEntity()
    {
       
    }
    public RepairEntity(Guid id, int rating, string comment, float cost, DateTime dateInit, DateTime dateEnd, DateTime dateEstimated)
    {
        Rating = rating;
        Comment = comment;
        Cost = cost;
        DateInit = dateInit;
        DateEnd = dateEnd;
        DateEstimated = dateEstimated;
    }
    public static RepairWrapper CreateWrapper(int rating, string comment, float price, DateTime dateInit, DateTime dateEnd, DateTime dateEstimated,bool firstTime)
    {
        if(rating < 0 || rating > 10) return new RepairWrapper()
        {
            IsSuccess = false,
            Value = null,
            ErrorMessage = "Rating must be between 0 and 10"
        };
        if(dateInit > dateEnd) return new RepairWrapper()
        {
            IsSuccess = false,
            Value = null,
            ErrorMessage = "Date init must be before date end"
        };
        if(dateEstimated < dateInit) return new RepairWrapper()
        {
            IsSuccess = false,
            Value = null,
            ErrorMessage = "Date estimated must be after date init"
        };
        float cost = 0;
        var time = (dateEnd - dateInit).TotalHours;
        var timeRetarded = (dateEnd - dateEstimated).TotalHours;
        var flag = false;
        if (firstTime)
        {
            price += price * 0.01f;
            cost = price * (float)time;
            flag = true;
        }
        if (dateEstimated < dateEnd)
        {
            var desc = price * 0.01f;
            if(!flag) cost += price * (float)time;
            cost -= desc * (float)timeRetarded;
            flag = true;
        }
        if(!flag) cost = price * (float)time;
        var repair = new RepairEntity(Guid.NewGuid(),rating, comment, cost, dateInit, dateEnd, dateEstimated);
        return new RepairWrapper
        {
            IsSuccess = true,
            Value = repair,
            ErrorMessage = null
        };
    }
}