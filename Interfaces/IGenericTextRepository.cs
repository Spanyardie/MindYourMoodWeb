using MindYourMoodWeb.DTOs;
using MindYourMoodWeb.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace MindYourMoodWeb.Interfaces
{
    public interface IGenericTextRepository
    {
        void Update(GenericText genericText);
        Task<IEnumerable<GenericTextDto>> GetGenericTextsAsync(int userId);
        Task<GenericText> GetGenericTextAsync(int genericTextId);
        void AddGenericText(GenericText genericTextItem);
        void RemoveGenericText(GenericText genericText);
    }
}
