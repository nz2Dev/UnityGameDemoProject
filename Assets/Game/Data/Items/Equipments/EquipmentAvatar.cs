using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Data.Items.Equipments
{
    public class EquipmentAvatar : MonoBehaviour
    {
        List<Equipment> equiped = new List<Equipment>();

        public bool Equipe(Equipment equipment)
        {
            if (IsEquiped(equipment))
            {
                return false;
            }

            equiped.Add(equipment);
            return true;
        }

        public bool Unequipe(EquipmentSlot equipmentSlot)
        {
            throw new NotImplementedException();
        }

        bool IsEquiped(Equipment equipment)
        {
            return equiped.Contains(equipment);
        }

    }
}