namespace razor_of_2022.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class Game
{

    public int GameId { get; set; }

    public string? Title { get; set; }

    [Column(TypeName = "decimal(6,2)")]

    public decimal Price { get; set; } = 5.99M;

    [Display(Name = "Date Published")]
    [DataType(DataType.Date)]
    public DateTime DatePublished { get; set; }

    public string? Genre { get; set; }


}