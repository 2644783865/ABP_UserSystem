using Abp.Application.Services;
using System.Collections.Generic;
using Cbd.Fgw.Application.System.Menu.Dto;

namespace Cbd.Fgw.Application.System.Menu {
    public interface IMenuService : IApplicationService {
        List<MenuDto> GetAll();
        /// <summary>
        /// ��ȡMenu����
        /// </summary>
        /// <returns></returns>
        Core.System.Menu GetMenu(int id);
        /// <summary>
        /// ��ȡMenuDto����
        /// </summary>
        /// <returns></returns>
        MenuDto Get(int id);
        MenuSearchOutputDto Get(MenuSearchInputDto input);
        void Create(MenuCreateInputDto input);
        void Edit(MenuEditInputDto input);
        void Delete(int id);
    }
}