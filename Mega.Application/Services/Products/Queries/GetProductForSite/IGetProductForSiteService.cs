using Mega.Common.Dto;
using System.Text;
using System.Threading.Tasks;

namespace Mega.Application.Services.Products.Queries.GetProductForSite
{
    public interface IGetProductForSiteService
    {
        KhorojiDto<ResultProductForSiteDto> Execute(Ordering ordering, string SearchKey, int Page,int pagesize, int? CatId);
    }
    public enum Ordering
    {

        NotOrder = 0,
        /// <summary>
        /// پربازدیدترین
        /// </summary>
        MostVisited = 1,
        /// <summary>
        /// پرفروشترین
        /// </summary>
        Bestselling = 2,
        /// <summary>
        /// محبوبترین
        /// </summary>
        MostPopular = 3,
        /// <summary>
        /// جدیدترین
        /// </summary>
        theNewest = 4,
        /// <summary>
        /// ارزانترین
        /// </summary>
        Cheapest = 5,
        /// <summary>
        /// گرانترین
        /// </summary>
        theMostExpensive = 6
    }

}



