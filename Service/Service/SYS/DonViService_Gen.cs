﻿//------------------------------------------------------------------------------------------------------------------------
//-- Generated By:   TrungVK using CodeSmith 6.0.0.0
//-- Template:       ServiceGen.cst
//-- Date Generated: Thursday, December 13, 2012
//------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using Entity;
using System.ComponentModel;
namespace SystemManageService
{
    public partial class DonViService
    {
        private DonViDataAccess _donviDataAccess = new DonViDataAccess();

        public int InsertDonVi(DonVi donvi)
        {
            return _donviDataAccess.InsertDonVi(donvi);
        }

        public int UpdateDonVi(List<DonVi> donvis)
        {
            return _donviDataAccess.UpdateDonVi(donvis);
        }

        public void UpdateDonVi(DonVi donvi)
        {
            _donviDataAccess.UpdateDonVi(donvi);
        }

        public void DeleteDonVi(List<DonVi> donvis)
        {
            _donviDataAccess.DeleteDonVi(donvis);
        }

        public void DeleteDonVi(DonVi donvis)
        {
            _donviDataAccess.DeleteDonVi(donvis);
        }

        public DonVi SelectDonVi(int donviId)
        {
            return _donviDataAccess.SelectDonVi(donviId);
        }

        public List<DonVi> SelectAllDonVi()
        {
            return _donviDataAccess.SelectAllDonVi();
        }
        public List<DonVi> DonVi_SelectAll_GroupBy_LoaiCS(string IDDonVi)
        {
            return _donviDataAccess.DonVi_SelectAll_GroupBy_LoaiCS(IDDonVi);
        }

        public BindingList<DonVi> SelectBindingAllDonVi()
        {
            return _donviDataAccess.SelectBindingAllDonVi();
        }


    }
}



