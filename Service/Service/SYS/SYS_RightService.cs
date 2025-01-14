//------------------------------------------------------------------------------------------------------------------------
//-- Generated By:   TrungVK using CodeSmith 5.0.0.0
//-- Template:       Service.cst
//-- Date Generated: Monday, July 12, 2010
//------------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;

namespace SystemManageService
{
    public partial class SYS_RightService
    {
        public List<SYS_Right> GetRightsByOfUser(int IDuser)
        {
            return _sys_rightDataAccess.GetRightsByUser(IDuser);
        }
        public List<SYS_Right> GetRightsByUser(int user)
        {
            List<SYS_Right> result = new List<SYS_Right>();
            List<SYS_Right> list = _sys_rightDataAccess.GetAllRightsByUser(user);
            //foreach (SYS_Right right in list)
            //{
            //    if (result.Count == 0)
            //    {
            //        result.Add(right);
            //        continue;
            //    }
            //    for (int i = result.Count-1; i > -1; i--)
            //    {
            //        if (right.ID == result[i].ID)
            //        {
            //            result[i].IsApprove = result[i].IsApprove || right.IsApprove;
            //            result[i].IsCreate = result[i].IsCreate || right.IsCreate;
            //            result[i].IsDelete = result[i].IsDelete || right.IsDelete;
            //            result[i].IsUpdate = result[i].IsUpdate || right.IsUpdate;
            //            break;
            //        }
            //        if (i==0)
            //        {
            //            result.Add(right);
            //        }
            //    }
            //}
            return list;
        }

        public List<SYS_Right> GetRightsByUser(SYS_User user, string connect)
        {
            List<SYS_Right> result = new List<SYS_Right>();
            List<SYS_Right> list = _sys_rightDataAccess.GetAllRightsByUser(user,connect);
            foreach (SYS_Right right in list)
            {
                if (result.Count == 0)
                {
                    result.Add(right);
                    continue;
                }
                for (int i = result.Count - 1; i > -1; i--)
                {
                    if (right.ID == result[i].ID)
                    {
                        result[i].IsApprove = result[i].IsApprove || right.IsApprove;
                        result[i].IsCreate = result[i].IsCreate || right.IsCreate;
                        result[i].IsDelete = result[i].IsDelete || right.IsDelete;
                        result[i].IsUpdate = result[i].IsUpdate || right.IsUpdate;
                        break;
                    }
                    if (i == 0)
                    {
                        result.Add(right);
                    }
                }
            }
            return result;
        }

        public List<SYS_Right> GetRightsByRole(SYS_Roles roles)
        {
           return _sys_rightDataAccess.GetRightsByRole(roles);
        } 
        public List<SYS_Right> GetRightsByNotRole(SYS_Roles roles)
        {
           return _sys_rightDataAccess.GetRightsByNotRole(roles);
        }

        public List<SYS_Right> GetRightsByNotUser(SYS_User user)
        {
            return _sys_rightDataAccess.GetRightsByNotUser(user);
        }  
    

        public void UpdateRightsOfRole(SYS_Roles roles)
        {
            _sys_rightDataAccess.UpdateRightsOfRole(roles);
        }

        public int SelectMaxTag()
        {
            return _sys_rightDataAccess.SelectMaxTag();
        }

        public int SelectMaxFuncID()
        {
            return _sys_rightDataAccess.SelectMaxFuncID();
        }
    }
}


