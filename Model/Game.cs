namespace razor_of_2022.Model;
using System.ComponentModel.DataAnnotations;
public class Game
{

    public int GameId { get; set; }

    public string? Title { get; set; }

    public decimal Price { get; set; } = 5.99M;

    [DataType(DataType.Date)]
    public DateTime DatePublished { get; set; }

    public string? Genre { get; set; }


}