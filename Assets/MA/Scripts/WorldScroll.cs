using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldScroll : MonoBehaviour
{

    [SerializeField] Transform player;
    Vector2Int currenttile = new Vector2Int(0,0);
    [SerializeField] Vector2Int playercurrenttile;
    Vector2Int onTileGridPlayerPosition;

    [SerializeField] float tilesize = 20f;

    GameObject[,] terraintiles;

    [SerializeField] int terraintileXcount;
    [SerializeField] int terraintileYcount;

    [SerializeField] int fieldvisionheight = 3;
    [SerializeField] int fieldvisionwidth = 3;

    private void Awake()
    {
        terraintiles = new GameObject[terraintileXcount, terraintileYcount];
    }

    public void Add(GameObject tilegameObject, Vector2Int tileposition)
    {
        terraintiles[tileposition.x, tileposition.y] = tilegameObject;
    }


    // Start is called before the first frame update
    void Start()
    {
        //UpdateTileScreen();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            playercurrenttile.x = (int)(player.position.x / tilesize);
            playercurrenttile.y = (int)(player.position.y / tilesize);

            playercurrenttile.x -= player.position.x < 0 ? 1 : 0;
            playercurrenttile.y -= player.position.y < 0 ? 1 : 0;
        }
        if (currenttile != playercurrenttile)
        {
            currenttile = playercurrenttile;
            onTileGridPlayerPosition.x = CalculatetheTile(onTileGridPlayerPosition.x , true);
            onTileGridPlayerPosition.y = CalculatetheTile(onTileGridPlayerPosition.y, false);

            UpdateTileScreen();
        }

    }

    private void UpdateTileScreen()
    {
        for (int pov_x = -(fieldvisionwidth/2); pov_x <= fieldvisionwidth/2; pov_x++)
        {
            for(int pov_y = -(fieldvisionheight/2); pov_y <= fieldvisionheight/2; pov_y++)
            {
                int tileToUpdateX = CalculatetheTile(playercurrenttile.x + pov_x, true);
                int tileToUpdateY = CalculatetheTile(playercurrenttile.y + pov_y, false);

                GameObject tile = terraintiles[tileToUpdateX, tileToUpdateY];
                //tile.transform.position = CalcilateTilePosition(playercurrenttile.x + pov_x, playercurrenttile.y + pov_y);

                //New to have a new position
                Vector3 newPosition = CalcilateTilePosition(playercurrenttile.x + pov_x, playercurrenttile.y + pov_y);

                if(newPosition != tile.transform.position)
                {
                    tile.transform.position = newPosition;

                    //Create to instance to have a breakable objects
                    terraintiles[tileToUpdateX, tileToUpdateY].GetComponent<TerrainTile>().Spawn();
                }

                

            }


        }
    }

    private Vector3 CalcilateTilePosition(int x, int y)
    {
        return new Vector3(x * tilesize, y * tilesize, 0f);
    }

    private int CalculatetheTile(int currentValue, bool horizontal)
    {
        if(horizontal)
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terraintileXcount;
            }
            else
            {
                currentValue += 1;
                currentValue = terraintileXcount - 1 + currentValue % terraintileXcount;
            }

        }
        else
        {
            if (currentValue >= 0)
            {
                currentValue = currentValue % terraintileYcount;
            }
            else
            {
                currentValue += 1;
                currentValue = terraintileYcount - 1 + currentValue % terraintileYcount;
            }
        }

        return (int)currentValue;

    }




}
