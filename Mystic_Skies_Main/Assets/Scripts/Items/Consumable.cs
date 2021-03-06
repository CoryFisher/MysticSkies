﻿using UnityEngine;
using System.Collections;

public class Consumable : MonoBehaviour
{
	public ItemManager.ConsumableType type;

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Floor"))
		{
			rigidbody.velocity = Vector3.zero;
			rigidbody.Sleep();
		}
		if(other.CompareTag("Player"))
		{
			Player player = other.GetComponent<Player>();

			if(player)
			{
				switch(type)
				{
					case ItemManager.ConsumableType.HealthShard:
					{
						player.IncreaseHealth(ItemManager.GetValue(type));
						break;
					}
					case ItemManager.ConsumableType.PotionHealth:
					{
						player.AddPotion(ItemManager.PotionType.Health);
						break;
					}
					case ItemManager.ConsumableType.PotionMana:
					{
						player.AddPotion(ItemManager.PotionType.Mana);
						break;
					}
					case ItemManager.ConsumableType.PotionRejuv:
					{
						player.AddPotion(ItemManager.PotionType.Rejuv);
						break;
					}
					case ItemManager.ConsumableType.MaxHealthShard:
					{
						player.IncreaseMaxHealth(ItemManager.GetValue(type));
						break;
					}
					case ItemManager.ConsumableType.MaxMagicShard:
					{
						player.IncreaseMaxFireMana(ItemManager.GetValue(type));
						player.IncreaseMaxWaterMana(ItemManager.GetValue(type));
						player.IncreaseMaxRockMana(ItemManager.GetValue(type));
						break;
					}
					case ItemManager.ConsumableType.MagicRegenShard:
					{
						player.IncreaseMagicRegen((float)ItemManager.GetValue(type) / 100.0f);
						break;
					}
					case ItemManager.ConsumableType.StrengthShard:
					{
						player.IncreaseStrength((float)ItemManager.GetValue(type) / 100.0f);
						break;
					}
					case ItemManager.ConsumableType.ToughnessShard:
					{
						player.IncreaseToughness((float)ItemManager.GetValue(type) / 100.0f);
						break;
					}
				}

				print ("ItemType = " + type.ToString());
				
				Destroy(gameObject);
			}
		}

	}

//	void OnCollisionEnter(Collision collision)
//	{
//		if(collision.collider.CompareTag("Floor"))
//		{
//			rigidbody.velocity = Vector3.zero;
//			//rigidbody.isKinematic = true;
//			rigidbody.Sleep();
//		}
//	}
}
