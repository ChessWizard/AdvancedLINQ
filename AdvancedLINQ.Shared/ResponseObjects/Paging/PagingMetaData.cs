using AdvancedLINQ.Shared.ResponseObjects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedLINQ.Shared.ResponseObjects.Paging
{
    public class PagingMetaData 
    {
        public int PageSize { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int TotalCount { get; set; }

        public bool HasPrevious => CurrentPage > 1;// var olan sayfa 1 den büyükse, demek ki bir önceki sayfa vardır

        public bool HasNext => CurrentPage < TotalPages;// bulunulan sayfa tüm sayfa sayısından küçükse demek ki hala gidilecek sayfa vardır.

        public PagingMetaData(int pageSize, int currentPage, int totalCount)
        {
            PageSize = pageSize;
            CurrentPage = currentPage;            
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
        }
    }
}
