using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class Upgrade
{
    private string upgradeName;
    private string imageUrl;
    private int cost;
    private bool equiped;

    public string UpgradeName { get { return upgradeName; } set { upgradeName = value; } }
    public string ImageUrl { get { return imageUrl; } set { imageUrl = value; } }
    public int Cost { get { return cost; } set { cost = value; } }
    public bool Equiped { get { return equiped; } set { equiped = value; } }
}