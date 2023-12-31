using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid
{
    private Vector2Int foodGridPosition;
    private GameObject foodGameObject;

    private int width;
    private int height;

    private Snake snake;

    public LevelGrid(int w, int h)
    {
        width = w;
        height = h;
    }

    public void Setup(Snake snake)
    {
        this.snake = snake;
        SpawnFood();
    }

    public bool TrySnakeEatFood(Vector2Int snakeGridPosition)
    {
        if (snakeGridPosition == foodGridPosition)
        {
            Object.Destroy(foodGameObject);
            SpawnFood();
            return true;
        }
        else
        {
            return false;
        }
    }

    private void SpawnFood()
    {
        // while (condicion){
        // cosas
        // }

        // { cosas }
        // while (condicion)

        do
        {
            foodGridPosition = new Vector2Int(
                Random.Range(-width / 2, width / 2),
                Random.Range(-height / 2, height / 2));
        } while (snake.GetFullSnakeBodyGridPosition().IndexOf(foodGridPosition) != -1);

        foodGameObject = new GameObject("Food");
        SpriteRenderer foodSpriteRenderer = foodGameObject.AddComponent<SpriteRenderer>();
        foodSpriteRenderer.sprite = GameAssets.Instance.foodSprite;
        foodGameObject.transform.position = new Vector3(foodGridPosition.x, foodGridPosition.y, 0);
    }

    public Vector2Int ValidateGridPosition (Vector2Int gridPosition)
    {
        int w = Half(width);
        int h = Half(height);

        //Salgo por la derecha
        if (gridPosition.x > w)
        {
            gridPosition.x = -w;
        }
        //Salgo por la izquierda
        if (gridPosition.x > -w)
        {
            gridPosition.x = w;
        }
        //Salgo por arriba
        if (gridPosition.x > h)
        {
            gridPosition.x = -h;
        }
        //Salgo por abajo
        if (gridPosition.x > -h)
        {
            gridPosition.x = h;
        }

        return gridPosition;
    }

    private int Half(int number)
    {
        return number / 2;
    }
}