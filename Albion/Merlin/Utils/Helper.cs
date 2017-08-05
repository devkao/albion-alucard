using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alucard.Utils
{
    public static class Helper
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool SetCursorPos(int x, int y);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

        public const int MOUSEEVENTF_LEFTDOWN = 0x02;
        public const int MOUSEEVENTF_LEFTUP = 0x04;

        //This simulates a left mouse click
        public static void LeftMouseClick(int xpos, int ypos)
        {
            SetCursorPos(xpos, ypos);
            mouse_event(MOUSEEVENTF_LEFTDOWN, xpos, ypos, 0, 0);
            mouse_event(MOUSEEVENTF_LEFTUP, xpos, ypos, 0, 0);
        }

        //public override float GetMoveSpeed()
        //{
        //    if (base.FightingObject.xm())
        //    {
        //        float num = (!this.IsMounted) ? this.ai : base.FightingObject.iq();
        //        return num / 10f;
        //    }
        //    if (base.FightingObject.v5().f() == 6)
        //    {
        //        asm asm = base.FightingObject.v5().h() as asm;
        //        if (asm.il() != fe.MovementTypes.Knockback)
        //        {
        //            return asm.@in() / 10f;
        //        }
        //    }
        //    return 0f;
        //}

        //public static void AddDebugGui()
        //{
        //    WorldObjectDebugGui gui = (WorldObjectDebugGui)Core._coreObject.gameObject.AddComponent(typeof(WorldObjectDebugGui));
        //    gui.Name = this.Mob.ir() + this.Mob.az();
        //    gui.AddValue("ActionState", () => this.Mob.xp().ToString().Substring(this.Mob.xp().ToString().LastIndexOf('.') + 1));
        //    gui.AddValue("MoveState", () => this.Mob.xq().ToString().Substring(this.Mob.xq().ToString().LastIndexOf('.') + 1));
        //    gui.AddValue("MoveSpeed", () => this.Mob.iq().ToString());
        //    gui.AddValue("GetMoveSpeed()", () => this.GetMoveSpeed().ToString());
        //    gui.AddValue("NWM Mode", () => (this.Mob.v0().aa() == null) ? "null" : this.Mob.v0().aa().j().ToString());
        //    gui.AddValue("NWM Target", () => (this.Mob.v0().aa() == null) ? "null" : this.Mob.v0().aa().f().ToString());
        //    gui.AddValue("NWM Dist", delegate {
        //        this.DrawDebugStuff();
        //        if (this.Mob.v0().aa() != null)
        //        {
        //            return ajc.c(this.Mob.hy(), this.Mob.v0().aa().f()).k().ToString("0.00");
        //        }
        //        return "???";
        //    });
        //}

    }
}
