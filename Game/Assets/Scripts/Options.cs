using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Options
{
    private int key_down;
    private int key_left;
    private int key_right;
    private int key_shoot;
    private int key_up;
    private int master_sound;

    public int Key_down { get { return key_down; } set { key_down = value; } }
    public int Key_left { get { return key_left; } set { key_left = value; } }
    public int Key_right { get { return key_right; } set { key_right = value; } }
    public int Key_shoot { get { return key_shoot; } set { key_shoot = value; } }
    public int Key_up { get { return key_up; } set { key_up = value; } }
    public int Master_sound { get { return master_sound; } set { master_sound = value; } }


}