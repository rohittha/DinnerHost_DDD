# Domain Models

## Menu

```charp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
  "id": "00000000-0000-0000-0000-000000000000",
  "name": "Vegan Menu",
  "description": "A menu with yummy vegan food",
  "averageRating": 4.5,
  "sections": [
    {
      "id": "00000000-0000-0000-0000-000000000000",
      "name": "Appetizer",
      "description": "Starter food snacks",
      "items": [
        {
          "id": "00000000-0000-0000-0000-000000000000",
          "name": "Vegan Menu",
          "description": "A menu with yummy vegan food",
          "price": 5.99
        }
      ]
    }
  ],
  "createdDateTime": "2022-04-08T08:00:00",
  "updatedDateTime": "2022-04-08T11:00:00",
  "hostId": "Vegan Sunshine",
  "dinnerIds": ["00000000-0000-0000-0000-000000000000"],
  "menuReviewIds": ["00000000-0000-0000-0000-000000000000"]
}
```
