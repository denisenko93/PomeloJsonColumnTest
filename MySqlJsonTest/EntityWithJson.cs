using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MySqlJsonTest;

public class EntityWithJson
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("json", TypeName = "json")]
    public SampleJson Json { get; set; }
}