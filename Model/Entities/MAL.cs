using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("mal")]
public class MAL
{
    [Key, Required]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("genres")]
    public string? Genres { get; set; }

    [Column("year")]
    public int Year { get; set; }
}
