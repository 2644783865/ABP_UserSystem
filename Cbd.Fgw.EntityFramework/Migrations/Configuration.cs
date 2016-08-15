using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Cbd.Fgw.Core.System;
using Cbd.Fgw.EntityFramework.EntityFramework;

namespace Cbd.Fgw.EntityFramework.Migrations {
    internal sealed class Configuration : DbMigrationsConfiguration<FgwDbContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Fgw";
        }

        protected override void Seed(FgwDbContext context) {
            //��ʼ����������
            var departments = new List<Department>
            {
                new Department
                {
                    DepartmentName = "������",
                    Describe = "����������ϵͳ����֯",
                    IsSystem = true
                },
                new Department
                {
                    DepartmentName = "Ͷ�ʿ�",
                    Describe = "����Ͷ�ʹܿص�ҵ���š�",
                    DepartmentId = 1
                },
                new Department
                {
                    DepartmentName = "���̿�",
                    Describe = "�������ʵ�ҵ���š�",
                    DepartmentId = 1
                },
                new Department
                {
                    DepartmentName = "CBDͨ��",
                    Describe = "��ʽͶ��ʹ��ǰ��ϵͳ�Ĳ��Բ��š�",
                    DepartmentId = 1
                }
            };
            departments.ForEach(d => context.Departments.Add(d));

            var menuGroups = new List<Menu>
            {
                new Menu {MenuName = "��Ŀ����", IsMenuGroup=true, Icon = "fa fa-database"},
                new Menu {MenuName = "ͳ�Ʋ�ѯ", IsMenuGroup=true, Icon = "fa fa-bar-chart"},
                new Menu {MenuName = "ϵͳ����", IsMenuGroup=true, Icon = "fa fa-cog"}
            };
            menuGroups.ForEach(m => { context.Menus.Add(m); });

            var childrenMenus = new List<Menu>
            {

                new Menu {MenuName = "�½���Ŀ", MenuUrl = "", ParentMenuId = 1},
                new Menu {MenuName = "��Ŀ����", MenuUrl = "", ParentMenuId = 1},
                new Menu {MenuName = "��Ŀ����", MenuUrl = "", ParentMenuId = 1},
                new Menu {MenuName = "������Ŀ", MenuUrl = "", ParentMenuId = 1},

                new Menu {MenuName = "��Ŀͳ��", MenuUrl = "", ParentMenuId = 2},

                new Menu {MenuName = "�û�����", MenuUrl = "system/User", ParentMenuId = 3},
                new Menu {MenuName = "��ɫ����", MenuUrl = "system/Role", ParentMenuId = 3},
                new Menu {MenuName = "���Ź���", MenuUrl = "system/Department", ParentMenuId = 3},
                new Menu {MenuName = "�˵�����", MenuUrl = "system/Menu", ParentMenuId = 3},
                new Menu {MenuName = "��־����", MenuUrl = "system/SysLog", ParentMenuId = 3}
            };
            childrenMenus.ForEach(m => context.Menus.Add(m));

            var role = new Role {
                RoleName = "��������Ա",
                IsSystem = true,
                Describe = "��������Աӵ��ϵͳ���Ȩ�ޣ�����ϵͳ�������޷�ɾ���ͱ༭��",
                Menus = new List<Menu>()
            };
            context.Roles.Add(role);
            var adminRole = new List<Menu>();
            adminRole.AddRange(menuGroups);
            adminRole.AddRange(childrenMenus);
            role.Menus = adminRole;

            var user = new User {
                UserName = "admin",
                RealName = "����Ա",
                Pwd = "123",
                DepartmentId = 2,
                IsActive = true,
                IsSystem = true,
                Roles = new List<Role>()
            };
            context.Users.Add(user);

            user.Roles = new List<Role> { role };
            context.SaveChangesAsync();
        }
    }
}
