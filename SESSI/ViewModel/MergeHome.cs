using SESSI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SESSI.ViewModel
{
    public class MergeHome
    {
        public List<HomeBanner> MergeHomeBanner { get; set; }
        public List<HomeTeam> MergeHomeTeam { get; set; }
        public List<HomeGallery> MergeHomeGallery { get; set; }
    }
}