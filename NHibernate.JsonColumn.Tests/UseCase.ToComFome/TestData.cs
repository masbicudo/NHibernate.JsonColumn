using System.Collections.Generic;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.JsonModels;
using NHibernate.JsonColumn.Tests.UseCase.ToComFome.Models;

namespace NHibernate.JsonColumn.Tests.UseCase.ToComFome
{
    internal static class TestData
    {
        internal static ProductModel GetTestProductModels()
        {
            var product = new ProductModel
            {
                Key = "Hamb-2",
                Title = "Hamburger 2",
                Description =
                        "Descrição do item 2. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                Photo = "~/Static/Images/foto2.jpg",
                Price = 7.50m,
                Customizer = new StackPanelControlModel()
                {
                    Fields = new ControlModel[]
                                {
                                    new DropdownButtonModel
                                        {
                                            Key = "cebola",
                                            Items = new[]
                                                {
                                                    new SelectItemModel("sem cebolas"),
                                                    new SelectItemModel("com cebolas"),
                                                    new SelectItemModel("dobro de cebolas", 1.00m),
                                                },
                                            Default = "1", // com cebola
                                        },
                                    new TextSwitchButtonModel
                                        {
                                            Key = "picles",
                                            Items = new[]
                                                {
                                                    new SelectItemModel("sem picles"),
                                                    new SelectItemModel("com picles"),
                                                },
                                            Default = "1", // com picles
                                        },
                                    new SwitchButtonModel
                                        {
                                            Key = "pimenta",
                                            Display = "pimenta",
                                            Default = "0", // sem pimenta
                                        },
                                    new SlideSwitchModel
                                        {
                                            Key = "queijo",
                                            Title = "queijo",
                                            CssClass = "amarelo",
                                            Default = "1", // com queijo
                                        },
                                    new ClassSwitchModel
                                        {
                                            Key = "salada",
                                            Title = "salada",
                                            ItemBuilder = new SelectItemBuilderModel
                                                {
                                                    CssClass = new[] { "switch-yes", "switch-no" },
                                                },
                                            Default = "0", // com salada
                                        },
                                    new CheckBoxModel
                                        {
                                            Key = "tomate",
                                            Title = "tomate",
                                            CssClass = "vermelho",
                                            Default = "0", // com salada
                                        },
                                    new TextSwitchButtonModel
                                        {
                                            Key = "batata",
                                            Title = "batata",
                                            ItemBuilder = new SelectItemBuilderModel
                                                {
                                                    Display = new[] { "pequena", "média", "grande" },
                                                    Price = new[] { 0.00m, 2.00m, 3.00m },
                                                },
                                            Default = "0", // com salada
                                        },
                                    new QueuePanelControlModel
                                        {
                                            Title = "bebida",
                                            Fields = new ControlModel[]
                                                {
                                                    new ImageSwitchButtonModel
                                                        {
                                                            Key = "tipo",
                                                            Title = "",
                                                            Items = new Dictionary<string, SelectItemModel>
                                                                {
                                                                    {
                                                                        "0",
                                                                        new SelectItemModel("~/Static/Images/Coca.png")
                                                                            {
                                                                                JsonProps = @"{""grupo"":""refri""}"
                                                                            }
                                                                    },
                                                                    {
                                                                        "1",
                                                                        new SelectItemModel(
                                                                            "~/Static/Images/FantaLar.png")
                                                                            {
                                                                                JsonProps = @"{""grupo"":""refri""}"
                                                                            }
                                                                    },
                                                                    {
                                                                        "2",
                                                                        new SelectItemModel(
                                                                            "~/Static/Images/FantaUva.png")
                                                                            {
                                                                                JsonProps = @"{""grupo"":""refri""}"
                                                                            }
                                                                    },
                                                                    {
                                                                        "100",
                                                                        new SelectItemModel(
                                                                            "~/Static/Images/SucoLar.png")
                                                                            {
                                                                                JsonProps = @"{""grupo"":""suco""}"
                                                                            }
                                                                    },
                                                                    {
                                                                        "101",
                                                                        new SelectItemModel(
                                                                            "~/Static/Images/SucoUva.png")
                                                                            {
                                                                                JsonProps = @"{""grupo"":""suco""}"
                                                                            }
                                                                    },
                                                                },
                                                            Default = "0", // coca-cola
                                                        },
                                                    new TextSwitchButtonModel
                                                        {
                                                            Key = "tamanho",
                                                            Title = "tamanho",
                                                            ItemBuilder = new SelectItemBuilderModel
                                                                {
                                                                    Key = new[] { "P", "M", "G" },
                                                                    Display = new[] { "pequena", "média", "grande" },
                                                                    IsVisible =
                                                                        "javascript:item.key!='G'||bebida.tipo.grupo=='refri'",
                                                                    Price =
                                                                        "javascript:{refri:{P:0,M:3.5,G:5},suco:{P:0,M:4.5}}[bebida.tipo.grupo][item.key]",
                                                                },
                                                            Default = "P", // pequena
                                                        },
                                                },
                                        },
                                    new TextBoxModel
                                        {
                                            Key = "obs",
                                            Title = "obs.",
                                            Default = "",
                                        },
                                },
                },
            };
            return product;
        }
    }
}