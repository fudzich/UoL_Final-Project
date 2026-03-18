using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastSpells : MonoBehaviour
{
    public Fire_Ignition fireIgnition;
    public Fire_Blast fireBlast;
    public Fire_SelfBurn fireSelfBurn;
    
    public Nature_SpawnFriend natureSpawnFriend;
    public Nature_Field natureField;
    public Nature_Regen natureRegen;
    
    public Earth_Cone earthCone;
    public Earth_LaunchBoulder earchLaunchBoulder;
    public Earth_SpawnWall earthSpawnWall;
    
    public Water_Beam waterBeam;
    public Water_Tornado waterTornado;
    public Water_Heal waterHeal;

    [SerializeField]
    public float rechargeTime = 2f;

    private float[] spellCooldownTimers = new float[4];
    private float[] spellCooldownDurations = new float[4];

    private MonoBehaviour[] spellScripts = new MonoBehaviour[4];

    private bool isHealCasting = false;
    private bool isTornadoCasting = false;
    private bool isBeamCasting = false;
    private bool waterCasting = false;

    public GameObject[] books;
    
    
    void Start()
    {
        CheckListOfSpells();

        spellCooldownDurations[0] = 1f; // For spell at index 0
        spellCooldownDurations[1] = 2f; // For spell at index 1
        spellCooldownDurations[2] = 3f; // For spell at index 2
        spellCooldownDurations[3] = 4f; // For spell at index 3
        for (int i = 0; i < spellCooldownTimers.Length; i++)
        {
            spellCooldownTimers[i] = 5f;
        }
    }
    
    void Update()
    {
        Debug.Log(PlayerInfo.isOnTile);
        for (int i = 0; i < spellCooldownTimers.Length; i++)
        {
            spellCooldownTimers[i] += Time.deltaTime;
        }
        ShowRechargedBooks();
        if (PlayerInfo.canCast)
        {
            CheckSpellPress(KeyCode.Alpha1, 0);
            CheckSpellPress(KeyCode.Alpha2, 1);
            CheckSpellPress(KeyCode.Alpha3, 2);
            CheckSpellPress(KeyCode.Alpha4, 3);
        }
    }

    private void CheckSpellPress(KeyCode key, int i)
    {
        //Debug.Log(spellCooldownTimers + " " + rechargeTime);
        if(spellScripts[i] != null && (spellCooldownTimers[i] >= spellCooldownDurations[i] || waterCasting))
        {
            if(spellScripts[i] == waterBeam && PlayerInfo.isOnTile == "Water")
            {
                CastBeam(PlayerInfo.spellsLevel[i], key, i);
            }
            else if (spellScripts[i] == waterTornado && PlayerInfo.isOnTile == "Water")
            {
                CastTornado(PlayerInfo.spellsLevel[i], key, i);
            }
            else if (spellScripts[i] == waterHeal && PlayerInfo.isOnTile == "Water")
            {
                CastHeal(PlayerInfo.spellsLevel[i], key, i);
            }
            else if (Input.GetKeyDown(key))
            {
                switch (spellScripts[i])
                {
                    case Fire_Ignition fireIgnition:
                        if(PlayerInfo.isOnTile == "Fire")
                        {
                            spellCooldownTimers[i] = 0;
                            CastIgnite(PlayerInfo.spellsLevel[i]);

                        }
                        break;
                    case Fire_Blast fireBlast:
                        if(PlayerInfo.isOnTile == "Fire")
                        {
                            spellCooldownTimers[i] = 0;
                            CastBlast(PlayerInfo.spellsLevel[i]);
                        }
                        break;
                    case Fire_SelfBurn fireSelfBurn:
                        if(PlayerInfo.isOnTile == "Fire")
                        {
                            spellCooldownTimers[i] = 0;
                            CastSelfBurn(PlayerInfo.spellsLevel[i]);
                        }
                        break;
                    case Nature_SpawnFriend natureSpawnFriend:
                        if(PlayerInfo.isOnTile == "Nature")
                        {
                            spellCooldownTimers[i] = 0;
                            CastSpawnFriend(PlayerInfo.spellsLevel[i]);
                        }
                        break;
                    case Nature_Field natureField:
                        if(PlayerInfo.isOnTile == "Nature")
                        {
                            spellCooldownTimers[i] = 0;
                            CastField(PlayerInfo.spellsLevel[i]);
                        }
                        break;
                    case Nature_Regen natureRegen:
                        if(PlayerInfo.isOnTile == "Nature")
                        {
                            spellCooldownTimers[i] = 0;
                            CastRegen(PlayerInfo.spellsLevel[i]);
                        }
                        break;
                    case Earth_Cone earthCone:
                        if(PlayerInfo.isOnTile == "Earth")
                        {
                            spellCooldownTimers[i] = 0;
                            CastCone(PlayerInfo.spellsLevel[i]);
                        }
                        break;
                    case Earth_LaunchBoulder earchLaunchBoulder:
                        if(PlayerInfo.isOnTile == "Earth")
                        {
                            spellCooldownTimers[i] = 0;
                            CastLaunchBoulder(PlayerInfo.spellsLevel[i]);
                        }
                        break;
                    case Earth_SpawnWall earthSpawnWall:
                        if(PlayerInfo.isOnTile == "Earth")
                        {
                            spellCooldownTimers[i] = 0;
                            CastSpawnWall(PlayerInfo.spellsLevel[i]);
                        }
                        break;
                }
                
            }
            
        }
    }

    private void CastIgnite(int lvl)
    {
        if (fireIgnition != null)
        {
            //Debug.Log("Cast");
            fireIgnition.Ignite(lvl);
        }
        else
        {
            Debug.LogWarning("fireIgnition reference is not set.");
        }
    }

    private void CastBlast(int lvl)
    {
        if (fireBlast != null)
        {
            //Debug.Log("Cast");
            fireBlast.Blast(lvl);
        }
        else
        {
            Debug.LogWarning("fireBlast reference is not set.");
        }
    }

    private void CastSelfBurn(int lvl)
    {
        if (fireSelfBurn != null)
        {
            //Debug.Log("Cast");
            fireSelfBurn.SelfBurn(lvl);
        }
        else
        {
            Debug.LogWarning("fireSelfBurn reference is not set.");
        }
    }

    private void CastSpawnFriend(int lvl)
    {
        if (natureSpawnFriend != null)
        {
            //Debug.Log("Cast");
            natureSpawnFriend.SpawnFriend(lvl);
        }
        else
        {
            Debug.LogWarning("natureSpawnFriend reference is not set.");
        }
    }

    private void CastRegen(int lvl)
    {
        if (natureRegen != null)
        {
            //Debug.Log("Cast");
            natureRegen.Regen(lvl);
        }
        else
        {
            Debug.LogWarning("natureRegen reference is not set.");
        }
    }

    private void CastField(int lvl)
    {
        if (natureField != null)
        {
            //Debug.Log("Cast");
            natureField.Field(lvl);
        }
        else
        {
            Debug.LogWarning("natureField reference is not set.");
        }
    }

    private void CastCone(int lvl)
    {
        if (earthCone != null)
        {
            //Debug.Log("Cast");
            earthCone.SpawnCone(lvl);
        }
        else
        {
            Debug.LogWarning("earthCone reference is not set.");
        }
    }

    private void CastLaunchBoulder(int lvl)
    {
        if (earchLaunchBoulder != null)
        {
            //Debug.Log("Cast");
            earchLaunchBoulder.LaunchBoulder(lvl);
        }
        else
        {
            Debug.LogWarning("earchLaunchBoulder reference is not set.");
        }
    }

    private void CastSpawnWall(int lvl)
    {
        if (earthSpawnWall != null)
        {
            //Debug.Log("Cast");
            earthSpawnWall.SpawnWall(lvl);
        }
        else
        {
            Debug.LogWarning("earthSpawnWall reference is not set.");
        }
    }

    private void CastHeal(int lvl, KeyCode key, int i)
    {
        waterCasting = true;
        if (Input.GetKey(key))
        {
            // Start casting if not already
            if (!isHealCasting)
            {
                isHealCasting = true;
            }
            // Continue casting: heal the player here
            waterHeal.Heal(lvl);
        }
        else
        {
            // If the button is released, stop casting
            if (isHealCasting)
            {
                waterCasting = false;
                isHealCasting = false;
                waterHeal.StopHeal();
                spellCooldownTimers[i] = 0;
            }
        }

        // 2. Check if any other key is pressed during casting to interrupt
        if (isHealCasting && Input.anyKeyDown && !Input.GetKeyDown(key))
        {
            waterCasting = false;
            isHealCasting = false;
            waterHeal.StopHeal();
            spellCooldownTimers[i] = 0;

        }
    }

    private void CastTornado(int lvl, KeyCode key, int i)
    {
        //waterCasting = true;
        if (Input.GetKey(key))
        {
            // Start casting if not already
            if (!isTornadoCasting)
            {
                isTornadoCasting = true;
                waterTornado.CastTornado(lvl);
            }
            // Continue casting: heal the player here
        }
        else
        {
            // If the button is released, stop casting
            if (isTornadoCasting)
            {
                //waterCasting = false;
                isTornadoCasting = false;
                waterTornado.StopTornado();
                spellCooldownTimers[i] = 0;
            }
        }

        // 2. Check if any other key is pressed during casting to interrupt
        if (isTornadoCasting && Input.anyKeyDown && !Input.GetKeyDown(key))
        {
            //waterCasting = false;
           isTornadoCasting = false;
            waterTornado.StopTornado();
            spellCooldownTimers[i] = 0;

        }
    }

    private void CastBeam(int lvl, KeyCode key, int i)
    {
        waterCasting = true;
        if (Input.GetKey(key))
        {
            // Start casting if not already
            if (!isBeamCasting)
            {
                isBeamCasting = true;
                waterBeam.FireBeam(lvl);
                //Debug.Log("beam cast");
            }
            // Continue casting: heal the player here
        }
        else
        {
            // If the button is released, stop casting
            if (isBeamCasting)
            {
                waterCasting = false;
                isBeamCasting = false;
                waterBeam.StopBeam();
                //Debug.Log("beam destroyed");
                spellCooldownTimers[i] = 0;
            }
        }

        // 2. Check if any other key is pressed during casting to interrupt
        if (isBeamCasting && Input.anyKeyDown && !Input.GetKeyDown(key))
        {
            waterCasting = false;
            isBeamCasting = false;
            waterBeam.StopBeam();
            spellCooldownTimers[i] = 0;

        }
    }
    
    public void CheckListOfSpells()
    {
        //foreach(string spellName in PlayerInfo.aquiredSpells)
        for (int i = 0; i < PlayerInfo.aquiredSpells.Length; i++)
        {
            switch (PlayerInfo.aquiredSpells[i])
            {
                case "Fire_Ignition":
                    spellScripts[i] = fireIgnition;
                    break;
                case "Fire_Blast":
                    spellScripts[i] = fireBlast;
                    break;
                case "Fire_SelfBurn":
                    spellScripts[i] = fireSelfBurn;
                    break;
                
                case "Nature_SpawnFriend":
                    spellScripts[i] = natureSpawnFriend;
                    break;
                case "Nature_Regen":
                    spellScripts[i] = natureRegen;
                    break;
                case "Nature_Field":
                    spellScripts[i] = natureField;
                    break;

                case "Earth_SpawnWall":
                    spellScripts[i] = earthSpawnWall;
                    break;
                case "Earth_Cone":
                    spellScripts[i] = earthCone;
                    break;
                case "Earth_LaunchBoulder":
                    spellScripts[i] = earchLaunchBoulder;
                    break;

                case "Water_Beam":
                    spellScripts[i] = waterBeam;
                    break;
                case "Water_Tornado":
                    spellScripts[i] = waterTornado;
                    break;
                case "Water_Heal":
                    spellScripts[i] = waterHeal;
                    break;

            }
        }
    }

    private void ShowRechargedBooks()
    {
        for(int i = 0; i < books.Length; i++)
        {
            MeshRenderer meshRenderer = books[i].GetComponent<MeshRenderer>();
            if (meshRenderer != null)
            {
                if (spellScripts[i] != null && spellCooldownTimers[i] >= spellCooldownDurations[i])
                {
                    SetMeshRendererActive(books[i], true);
                }
                else
                {
                    SetMeshRendererActive(books[i], false);
                }
            }
        }
    }

    private void SetMeshRendererActive(GameObject obj, bool isActive)
    {
        // Get all MeshRenderers in the object and its children
        MeshRenderer[] meshRenderers = obj.GetComponentsInChildren<MeshRenderer>();
        foreach (MeshRenderer renderer in meshRenderers)
        {
            renderer.enabled = isActive;
        }
    }
}
