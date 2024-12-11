﻿using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Xpo;

namespace MyProyectoXaf.Module.BusinessObjects;

[DefaultClassOptions]
[RuleCriteria("Precio Mayor que 0", DefaultContexts.Save, "Precio > 0 AND Stock >= 0", CustomMessageTemplate = "El precio debe ser mayor que 0.")]
[RuleCriteria("Stock Mayor que 0", DefaultContexts.Save, "Stock >= 0", CustomMessageTemplate = "El stock debe ser mayor que 0.")]
public class ProductoModule : BaseObject
{ // Inherit from a different class to provide a custom primary key, concurrency and deletion behavior, etc. (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument113146.aspx).
    // Use CodeRush to create XPO classes and properties with a few keystrokes.
    // https://docs.devexpress.com/CodeRushForRoslyn/118557
    public ProductoModule(Session session)
        : base(session)
    {
    }
    public override void AfterConstruction()
    {
        base.AfterConstruction();
        // Place your initialization code here (https://documentation.devexpress.com/eXpressAppFramework/CustomDocument112834.aspx).
    }

    ProveedoresModule proveedores;
    decimal precioUnitario;
    string stock;
    double precio;
    string nombre;
    CategoriaModule categoria;

    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Nombre
    {
        get => nombre;
        set => SetPropertyValue(nameof(Nombre), ref nombre, value);
    }

    public double Precio
    {
        get => precio;
        set => SetPropertyValue(nameof(Precio), ref precio, value);
    }

    [Size(SizeAttribute.DefaultStringMappingFieldSize)]
    public string Stock
    {
        get => stock;
        set => SetPropertyValue(nameof(Stock), ref stock, value);
    }

    [Association("Categoria-ProductosEspecials")]
    public CategoriaModule Categoria
    {
        get => categoria;
        set => SetPropertyValue(nameof(Categoria), ref categoria, value);
    }
    public decimal Fecha
    {
        get => precioUnitario;
        set => SetPropertyValue(nameof(Fecha), ref precioUnitario, value);
    }
    public decimal PrecioUnitario
    {
        get => precioUnitario;
        set => SetPropertyValue(nameof(PrecioUnitario), ref precioUnitario, value);
    }
    
    [Association("Proveedores-Productos")]
    public ProveedoresModule Proveedores
    {
        get => proveedores;
        set => SetPropertyValue(nameof(Proveedores), ref proveedores, value);
    }
}