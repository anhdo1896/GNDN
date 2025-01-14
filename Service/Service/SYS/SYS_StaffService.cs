//------------------------------------------------------------------------------------------------------------------------
//-- Generated By:   TrungVK using CodeSmith 5.0.0.0
//-- Template:       Service.cst
//-- Date Generated: Monday, July 12, 2010
//------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using Entity;
using DataAccess;
namespace SystemManageService
{
    public partial class SYS_StaffService
    {
        public SYS_OrganizationPositionRoleService _o = new SYS_OrganizationPositionRoleService();
        public SYS_PositionDataAccess _PositionDataAccess = new SYS_PositionDataAccess();
        public SYS_OrganizationDataAccess _organizationDataAccess = new SYS_OrganizationDataAccess();
        public SYS_StaffDataAccess _ISYS_StaffDataAccess = new SYS_StaffDataAccess();

        //public bool CheckStaff(SYS_Staff sys_staff)
        //{
        //    return _ISYS_StaffDataAccess.CheckStaff(sys_staff);
        //}

        public int InsertSYS_Staff(SYS_Staff sys_staff)
        {

            List<SYS_OrganizationPositionRole> list = _o.SelectByOP(sys_staff.OrganizationId, sys_staff.PositionId);
            if (list.Count > 0)
            {
                sys_staff.RoleID = list[0].RoleId;
                return _sys_staffDataAccess.InsertSYS_Staff(sys_staff);
            }
            else
            {
                throw new Exception("InsertSYS_Staff: OrganizationPositionRole don't have Role");
            }
        }

        public int UpdateSYS_Staff(List<SYS_Staff> sys_staffs)
        {
            int result = 0;

            for (int i = 0; i < sys_staffs.Count; i++)
            {
                UpdateSYS_Staff(sys_staffs[i]);
                result = i;
            }
            return result;
        }

        public void UpdateSYS_Staff(SYS_Staff sys_staff)
        {
            List<SYS_OrganizationPositionRole> list = _o.SelectByOP(sys_staff.OrganizationId, sys_staff.PositionId);
            if (list.Count > 0)
            {
                sys_staff.RoleID = list[0].RoleId;
                _sys_staffDataAccess.UpdateSYS_Staff(sys_staff);
            }
            else
            {
                throw new Exception("UpdateSYS_Staff: OrganizationPositionRole don't have Role");
            }
        }


        public List<SYS_Staff> SelectAllSYS_Staff(bool getOP)
        {
            DbConnection conn = DataAccess.Common.CreateConnection();
            conn.Open();
            List<SYS_Staff> result = _sys_staffDataAccess.SelectAllSYS_Staff(conn);
            if (getOP)
            {
                foreach (SYS_Staff sysStaff in result)
                {
                    sysStaff.Organization = _organizationDataAccess.SelectSYS_Organization(conn, sysStaff.OrganizationId);
                    sysStaff.Position = _PositionDataAccess.SelectSYS_Position(conn, sysStaff.PositionId);
                }

            }
            conn.Close();
            return result;
        }

        public DataTable dtSelectAllSYS_Staff()
        {
            DbConnection conn = DataAccess.Common.CreateConnection();
            conn.Open();
            return _sys_staffDataAccess.dtSelectAllSYS_Staff(conn);
        }
    }
}


