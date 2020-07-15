using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace SystemManageService
{
    public partial class DonViService
    {
        public List<DonVi> SelectAll_DonViByIDRegion(int IDRegion, int PhanLoai)
        {
            return _donviDataAccess.SelectAll_DonViByIDRegion(IDRegion, PhanLoai);
        }
        public List<DonVi> SelectAllDonViByRegionIDAndPhanLoai(int ID, int PhanLoai, int PhanLoaiDV)
        {
            return _donviDataAccess.SelectAllDonViByRegionIDAndPhanLoai(ID, PhanLoai, PhanLoaiDV);
        }
        public List<DonVi> SelectAllDonViByRegionIDAndPhanLoaiString(int ID, string PhanLoai)
        {
            return _donviDataAccess.SelectAllDonViByRegionIDAndPhanLoaiString(ID, PhanLoai);
        }

        public List<DonVi> SelectAllDonViByRegionID(int ID)
        {
            return _donviDataAccess.SelectAllDonViByRegionID(ID);
        }
        public List<DonVi> SelectAllDonViByParentID(int ParentID)
        {
            return _donviDataAccess.SelectAllDonViByParentID(ParentID);
        }
        public List<DonVi> SelectAllDonViByParentIDPhanLoai(int ParentID, int PhanLoai)
        {
            return _donviDataAccess.SelectAllDonViByParentIDPhanLoai(ParentID, PhanLoai);
        }

        public List<DonVi> SelectAllDonViByPhanLoai(int PhanLoai)
        {
            return _donviDataAccess.SelectAllDonViByPhanLoai(PhanLoai);
        }

        public List<DonVi> SelectDonViChuQuanLogin()
        {
            return _donviDataAccess.SelectDonViChuQuanLogin();
        }

        public List<DonVi> DonVi_SelectDVCQ(int ID)
        {
            return _donviDataAccess.DonVi_SelectDVCQ(ID);
        }
        public List<DonVi> SYS_Region_Organization_SelectByIDIDRegion(int IDIDRegion)
        {
            return _donviDataAccess.SYS_Region_Organization_SelectByIDIDRegion(IDIDRegion);
        }
        public List<DonVi> SelectAllDonViByParentID(int ParentID, int PhanLoai)
        {
            return _donviDataAccess.SelectAllDonViByParentID(ParentID, PhanLoai);
        }
    }
}
