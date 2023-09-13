#region

using System.ComponentModel.DataAnnotations;
using System.Text;

#endregion

namespace GameStore.api.Entities;

public class Game
{
    public int Id { get; set; }

    [ Required ]
    [ StringLength(50, MinimumLength = 3) ]
    public required string Name { get; set; }

    [ Required ]
    [ StringLength(20, MinimumLength = 3) ]
    public required string Genre { get; set; }

    [ Range(1, 500) ] public decimal Price { get; set; }

    public DateTime ReleaseDate { get; set; }

    [ Url ] public required string ImageUri { get; set; }

    public void Validate() {
        var context = new ValidationContext(this, serviceProvider : null, items : null);
        var results = new List<ValidationResult>();
        bool isValid = Validator.TryValidateObject(this, context, results, true);

        if (isValid == false) {
            var sbrErrors = new StringBuilder();
            foreach (var validationResult in results) {
                sbrErrors.AppendLine(validationResult.ErrorMessage);
            }

            throw new ValidationException(sbrErrors.ToString());
        }
    }
}