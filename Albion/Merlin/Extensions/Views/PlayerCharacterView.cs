using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Alucard
{
    public static class PlayerCharacterViewExtensions
    {
        public static string getAliance(this PlayerCharacterView instance)
        {
            return instance.PlayerCharacter.jn();
        }

        public static string getGuild(this PlayerCharacterView instance)
        {
            return instance.PlayerCharacter.jh();
        }

        public static string getTitle(this PlayerCharacterView instance)
        {
            return instance.PlayerCharacter.uz();
        }
    }
}
