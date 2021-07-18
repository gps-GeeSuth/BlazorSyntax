// Decompiled with JetBrains decompiler
// Type: ResturantClient.Pages.Web.customer.Cart
// Assembly: ResturantClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 353C9EF7-7679-442B-B028-DFC12AAA44C9
// Assembly location: D:\Async\Mega\Projects\Gramoli\UI\site1\ResturantClient.dll

using AssetsFunctions.dev;
using AssetsFunctions.Settings;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.CompilerServices;
using Microsoft.AspNetCore.Components.Rendering;
using Microsoft.AspNetCore.Components.Web;
using MudBlazor;
using Newtonsoft.Json;
using Resturant.Shared.DTOs;
using ResturantClient.Componets.global;
using ResturantClient.Componets.global.Localizations;
using ResturantClient.Constants;
using ResturantClient.Services.global;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ResturantClient.Pages.Web.customer
{
  [Route("/cart")]
  public class Cart : ComponentBase
  {
    private bool AllowOrder = true;
    private Decimal Total;
    private Decimal Tax;
    private Decimal Delivery;
    private Decimal Qty;
    private Decimal Price;
    private bool isWorking = true;
    private List<CartTemp> tempCart = new List<CartTemp>();

    protected override void BuildRenderTree(RenderTreeBuilder __builder)
    {
      __builder.OpenElement(0, "div");
      if (this.isWorking)
      {
        __builder.OpenComponent<LoadingImage>(1);
        __builder.CloseComponent();
      }
      else if (this.tempCart.Count == 0)
      {
        __builder.AddMarkupContent(2, "<p>Nothing Yet</p>");
      }
      else
      {
        __builder.OpenElement(3, "div");
        __builder.AddAttribute(4, "style", " height: 440px; overflow: scroll; overflow-y: scroll; overflow-x: hidden; }");
        foreach (CartTemp cartTemp in this.tempCart)
        {
          CartTemp item = cartTemp;
          __builder.OpenComponent<MudCard>(5);
          __builder.AddAttribute(6, "Style", "margin-bottom: 15px;");
          __builder.AddAttribute(7, "ChildContent", (MulticastDelegate) (__builder2 =>
          {
            __builder2.OpenComponent<MudCardContent>(8);
            __builder2.AddAttribute(9, "ChildContent", (MulticastDelegate) (__builder3 =>
            {
              __builder3.OpenComponent<MudGrid>(10);
              __builder3.AddAttribute(11, "ChildContent", (MulticastDelegate) (__builder4 =>
              {
                __builder4.OpenComponent<MudItem>(12);
                __builder4.AddAttribute(13, "xs", (object) RuntimeHelpers.TypeCheck<int>(2));
                __builder4.AddAttribute(14, "ChildContent", (MulticastDelegate) (__builder5 =>
                {
                  __builder5.OpenComponent<MudAvatar>(15);
                  __builder5.AddAttribute(16, "Image", RuntimeHelpers.TypeCheck<string>(this.getImagePath(item.IMG_PATH)));
                  __builder5.AddAttribute(17, "Size", (object) RuntimeHelpers.TypeCheck<Size>(Size.Large));
                  __builder5.AddAttribute(18, "Class", "ma-2");
                  __builder5.CloseComponent();
                }));
                __builder4.CloseComponent();
                __builder4.AddMarkupContent(19, "\r\n                                ");
                __builder4.OpenComponent<MudItem>(20);
                __builder4.AddAttribute(21, "xs", (object) RuntimeHelpers.TypeCheck<int>(6));
                __builder4.AddAttribute(22, "Style", "margin-left: 10px;");
                __builder4.AddAttribute(23, "ChildContent", (MulticastDelegate) (__builder5 =>
                {
                  __builder5.OpenComponent<MudText>(24);
                  __builder5.AddAttribute(25, "ChildContent", (MulticastDelegate) (__builder6 => __builder6.AddContent(26, this.getName(item))));
                  __builder5.CloseComponent();
                  __builder5.AddMarkupContent(27, "\r\n                                    ");
                  __builder5.OpenComponent<MudText>(28);
                  __builder5.AddAttribute(29, "ChildContent", (MulticastDelegate) (__builder6 => __builder6.AddContent(30, (object) item.PRICE)));
                  __builder5.CloseComponent();
                }));
                __builder4.CloseComponent();
                __builder4.AddMarkupContent(31, "\r\n                                ");
                __builder4.OpenComponent<MudItem>(32);
                __builder4.AddAttribute(33, "xs", (object) RuntimeHelpers.TypeCheck<int>(2));
                __builder4.AddAttribute(34, "ChildContent", (MulticastDelegate) (__builder5 =>
                {
                  __builder5.OpenComponent<MudButton>(35);
                  __builder5.AddAttribute(36, "Variant", (object) RuntimeHelpers.TypeCheck<Variant>(Variant.Filled));
                  __builder5.AddAttribute(37, "StartIcon", RuntimeHelpers.TypeCheck<string>(Icons.Material.Filled.Delete));
                  __builder5.AddAttribute(38, "Color", (object) RuntimeHelpers.TypeCheck<Color>(Color.Error));
                  __builder5.AddAttribute<MouseEventArgs>(39, "OnClick", RuntimeHelpers.TypeCheck<EventCallback<MouseEventArgs>>(EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (() => this.RemoveItemFromOrder(item.Guid)))));
                  __builder5.AddAttribute(40, "ChildContent", (MulticastDelegate) (__builder6 =>
                  {
                    __builder6.OpenComponent<LocalizationText>(41);
                    __builder6.AddAttribute(42, "Key", "DELETE");
                    __builder6.CloseComponent();
                  }));
                  __builder5.CloseComponent();
                }));
                __builder4.CloseComponent();
              }));
              __builder3.CloseComponent();
            }));
            __builder2.CloseComponent();
          }));
          __builder.CloseComponent();
        }
        __builder.CloseElement();
        __builder.AddMarkupContent(43, "\r\n            ");
        __builder.OpenElement(44, "div");
        __builder.OpenComponent<MudCard>(45);
        __builder.AddAttribute(46, "ChildContent", (MulticastDelegate) (__builder2 =>
        {
          __builder2.OpenComponent<MudCardContent>(47);
          __builder2.AddAttribute(48, "ChildContent", (MulticastDelegate) (__builder3 =>
          {
            __builder3.OpenComponent<MudGrid>(49);
            __builder3.AddAttribute(50, "ChildContent", (MulticastDelegate) (__builder4 =>
            {
              __builder4.OpenComponent<MudItem>(51);
              __builder4.AddAttribute(52, "xs", (object) RuntimeHelpers.TypeCheck<int>(12));
              __builder4.AddAttribute(53, "ChildContent", (MulticastDelegate) (__builder5 =>
              {
                __builder5.OpenComponent<MudGrid>(54);
                __builder5.AddAttribute(55, "ChildContent", (MulticastDelegate) (__builder6 =>
                {
                  __builder6.OpenComponent<MudItem>(56);
                  __builder6.AddAttribute(57, "xs", (object) RuntimeHelpers.TypeCheck<int>(8));
                  __builder6.AddAttribute(58, "ChildContent", (MulticastDelegate) (__builder7 =>
                  {
                    __builder7.OpenComponent<MudText>(59);
                    __builder7.AddAttribute(60, "ChildContent", (MulticastDelegate) (__builder8 =>
                    {
                      __builder8.OpenComponent<LocalizationText>(61);
                      __builder8.AddAttribute(62, "Key", "TOTAL");
                      __builder8.CloseComponent();
                      __builder8.AddContent(63, " :");
                    }));
                    __builder7.CloseComponent();
                  }));
                  __builder6.CloseComponent();
                  __builder6.AddMarkupContent(64, "\r\n                                    ");
                  __builder6.OpenComponent<MudItem>(65);
                  __builder6.AddAttribute(66, "xs", (object) RuntimeHelpers.TypeCheck<int>(4));
                  __builder6.AddAttribute(67, "ChildContent", (MulticastDelegate) (__builder7 =>
                  {
                    __builder7.OpenComponent<MudText>(68);
                    __builder7.AddAttribute(69, "Style", "text-align: right;");
                    __builder7.AddAttribute(70, "ChildContent", (MulticastDelegate) (__builder8 => __builder8.AddContent(71, this.Price.ToString("0.00"))));
                    __builder7.CloseComponent();
                  }));
                  __builder6.CloseComponent();
                }));
                __builder5.CloseComponent();
              }));
              __builder4.CloseComponent();
              __builder4.AddMarkupContent(72, "\r\n                            ");
              __builder4.OpenComponent<MudItem>(73);
              __builder4.AddAttribute(74, "xs", (object) RuntimeHelpers.TypeCheck<int>(12));
              __builder4.AddAttribute(75, "ChildContent", (MulticastDelegate) (__builder5 =>
              {
                __builder5.OpenComponent<MudGrid>(76);
                __builder5.AddAttribute(77, "ChildContent", (MulticastDelegate) (__builder6 =>
                {
                  __builder6.OpenComponent<MudItem>(78);
                  __builder6.AddAttribute(79, "xs", (object) RuntimeHelpers.TypeCheck<int>(8));
                  __builder6.AddAttribute(80, "ChildContent", (MulticastDelegate) (__builder7 =>
                  {
                    __builder7.OpenComponent<MudText>(81);
                    __builder7.AddAttribute(82, "ChildContent", (MulticastDelegate) (__builder8 =>
                    {
                      __builder8.OpenComponent<LocalizationText>(83);
                      __builder8.AddAttribute(84, "Key", "VAT_AMOUNT");
                      __builder8.CloseComponent();
                      __builder8.AddContent(85, ":");
                    }));
                    __builder7.CloseComponent();
                  }));
                  __builder6.CloseComponent();
                  __builder6.AddMarkupContent(86, "\r\n                                    ");
                  __builder6.OpenComponent<MudItem>(87);
                  __builder6.AddAttribute(88, "xs", (object) RuntimeHelpers.TypeCheck<int>(4));
                  __builder6.AddAttribute(89, "ChildContent", (MulticastDelegate) (__builder7 =>
                  {
                    __builder7.OpenComponent<MudText>(90);
                    __builder7.AddAttribute(91, "Style", "text-align: right;");
                    __builder7.AddAttribute(92, "ChildContent", (MulticastDelegate) (__builder8 => __builder8.AddContent(93, this.Tax.ToString("0.00"))));
                    __builder7.CloseComponent();
                  }));
                  __builder6.CloseComponent();
                }));
                __builder5.CloseComponent();
              }));
              __builder4.CloseComponent();
              __builder4.AddMarkupContent(94, "\r\n                            ");
              __builder4.OpenComponent<MudItem>(95);
              __builder4.AddAttribute(96, "xs", (object) RuntimeHelpers.TypeCheck<int>(12));
              __builder4.AddAttribute(97, "ChildContent", (MulticastDelegate) (__builder5 =>
              {
                __builder5.OpenComponent<MudGrid>(98);
                __builder5.AddAttribute(99, "ChildContent", (MulticastDelegate) (__builder6 =>
                {
                  __builder6.OpenComponent<MudItem>(100);
                  __builder6.AddAttribute(101, "xs", (object) RuntimeHelpers.TypeCheck<int>(8));
                  __builder6.AddAttribute(102, "ChildContent", (MulticastDelegate) (__builder7 =>
                  {
                    __builder7.OpenComponent<MudText>(103);
                    __builder7.AddAttribute(104, "ChildContent", (MulticastDelegate) (__builder8 =>
                    {
                      __builder8.OpenComponent<LocalizationText>(105);
                      __builder8.AddAttribute(106, "Key", "DELIVERY_AMOUNT");
                      __builder8.CloseComponent();
                      __builder8.AddContent(107, ":");
                    }));
                    __builder7.CloseComponent();
                  }));
                  __builder6.CloseComponent();
                  __builder6.AddMarkupContent(108, "\r\n                                    ");
                  __builder6.OpenComponent<MudItem>(109);
                  __builder6.AddAttribute(110, "xs", (object) RuntimeHelpers.TypeCheck<int>(4));
                  __builder6.AddAttribute(111, "ChildContent", (MulticastDelegate) (__builder7 =>
                  {
                    __builder7.OpenComponent<MudText>(112);
                    __builder7.AddAttribute(113, "Style", "text-align: right;");
                    __builder7.AddAttribute(114, "ChildContent", (MulticastDelegate) (__builder8 => __builder8.AddContent(115, this.Delivery.ToString("0.00"))));
                    __builder7.CloseComponent();
                  }));
                  __builder6.CloseComponent();
                }));
                __builder5.CloseComponent();
              }));
              __builder4.CloseComponent();
            }));
            __builder3.CloseComponent();
          }));
          __builder2.CloseComponent();
          __builder2.AddMarkupContent(116, "\r\n                    ");
          __builder2.OpenComponent<MudCardActions>(117);
          __builder2.AddAttribute(118, "ChildContent", (MulticastDelegate) (__builder3 =>
          {
            __builder3.OpenComponent<MudButton>(119);
            __builder3.AddAttribute(120, "Variant", (object) RuntimeHelpers.TypeCheck<Variant>(Variant.Filled));
            __builder3.AddAttribute(121, "Disabled", RuntimeHelpers.TypeCheck<bool>(!this.AllowOrder));
            __builder3.AddAttribute(122, "FullWidth", RuntimeHelpers.TypeCheck<bool>(true));
            __builder3.AddAttribute(123, "Color", (object) RuntimeHelpers.TypeCheck<Color>(Color.Primary));
            __builder3.AddAttribute<MouseEventArgs>(124, "OnClick", RuntimeHelpers.TypeCheck<EventCallback<MouseEventArgs>>(EventCallback.Factory.Create<MouseEventArgs>((object) this, (Func<Task>) (async () => await this.CompleteOrder()))));
            __builder3.AddAttribute(125, "ChildContent", (MulticastDelegate) (__builder4 =>
            {
              __builder4.OpenComponent<LocalizationText>(126);
              __builder4.AddAttribute((int) sbyte.MaxValue, "Key", "COMPLETE_ORDER");
              __builder4.CloseComponent();
              __builder4.AddContent(128, " ");
              __builder4.AddContent(129, (object) this.Total);
            }));
            __builder3.CloseComponent();
          }));
          __builder2.CloseComponent();
        }));
        __builder.CloseComponent();
        __builder.CloseElement();
      }
      __builder.CloseElement();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
      Cart cart = this;
      if (!firstRender)
        return;
      int itemAsync1 = await cart.localStorage.GetItemAsync<int>(LocalStorgeParamater.CustomerId);
      ResultResponseObject resultResponseObject = ObjectFactory.ResultObj(await cart.userServices.getListCartTemp(itemAsync1));
      if (!resultResponseObject.Error)
      {
        List<CartTemp> cartTempList = JsonConvert.DeserializeObject<List<CartTemp>>(resultResponseObject.obj.ToString());
        cart.tempCart = cartTempList;
      }
      cart.isWorking = false;
      string itemAsync2 = await cart.localStorage.GetItemAsync<string>(LocalStorgeParamater.Token);
      await cart.SetSetting(itemAsync2);
      cart.StateHasChanged();
    }

    private string getName(CartTemp it) => GlobalBlazor.Language == "ar" ? it.NAME_AR : it.NAME_EN;

    public string getImagePath(string img) => (ApiConstants.api_url + AssetsFunctions.global.getImagePathFromJson(img)).Replace("\\", "/");

    private async Task CompleteOrder() => this.navManger.NavigateTo("completeOrder");

    private async Task RemoveItemFromOrder(Guid giud)
    {
      Cart cart = this;
      string itemAsync = await cart.localStorage.GetItemAsync<string>(LocalStorgeParamater.Token);
      if (ObjectFactory.ResultObj(await cart.userServicesAuth.RemoveItemFromOrder(giud, itemAsync)).Error)
        return;
      cart.navManger.NavigateTo(cart.navManger.BaseUri + "cart", true);
      cart.StateHasChanged();
    }

    private async Task SetSetting(string token)
    {
      ResultResponseObject resultResponseObject1 = ObjectFactory.ResultObj(await this.userServicesAuth.GetSetting(SettingApp.SETTING_CODE_DELIVERY_IS_ENABLE, token));
      if (!resultResponseObject1.Error)
        this.AllowOrder = Convert.ToBoolean(ObjectFactorySetting.ResultObj(resultResponseObject1.obj.ToString()).SETTING_VALUE);
      ResultResponseObject resultResponseObject2 = ObjectFactory.ResultObj(await this.userServicesAuth.GetSetting(SettingApp.SETTING_CODE_DELIVERY_AMOUNT_AN_ORDER, token));
      if (!resultResponseObject2.Error)
        this.Delivery = Convert.ToDecimal(ObjectFactorySetting.ResultObj(resultResponseObject2.obj.ToString()).SETTING_VALUE);
      this.calucate();
    }

    public void calucate()
    {
      foreach (CartTemp cartTemp in this.tempCart)
        this.Price += cartTemp.PRICE;
      this.Total = this.Price + this.Delivery;
      this.Qty = (Decimal) this.tempCart.Count;
    }

    [Inject]
    private IUserServicesAuth userServicesAuth { get; set; }

    [Inject]
    private NavigationManager navManger { get; set; }

    [Inject]
    private ILocalStorageService localStorage { get; set; }

    [Inject]
    private IUserServices userServices { get; set; }
  }
}
