# CircusCharlie
2023-01-31 Setup Basic    
2023-02-01 Setup Player, Obstacles, Enemy    
- Summary : 플레이어의 하위 오브젝트인 PlayerLion 오브젝트의 애니메이션 설정 이슈 발생    
- Detail :    
    1. PlayerLion 오브젝트가 이미지 기반이기 때문에 sprite를 드래그 해서 애니메이션을    
     했을 경우 sprite로 애니메이션이 구성되기 때문에 이미지 기반의 PlayerLion 오브젝트에    
     애니메이션이 적용되지 않았다.    

    2. window 툴에서 animation -> (하이어라키)오브젝트 선택 -> Create로 애니메이션을 만들고    
     imagesprite로 애니메이션을 설정한다.    
    
    3. Player의 애니메이션의 Image.Sprite에서 하위 Add Property에서 하위 오브젝트인    
     PlayerLion을 선택하고 Image.Sprite로 PlayerLion의 애니메이션을 선택하면    
     Player의 애니메이션과 PlayerLion의 애니메이션이 동기화가 된다.    


- Summary : 오브젝트 풀링 구현 중 생성된 타겟 오브젝트의 크기가 커지는 이슈 발생
- Detail :    
    1. 오브젝트 풀링의 CreateNewObject에서 Instantiate을 그냥 했을 경우 생성되는 이미지    
     의 크기가 GameObjs 오브젝트의 하위에서 벗어나기 때문에 크기가 커지는 것으로 추정된다.    

    2. var newObj = Instantiate(Object_Prefab,GameObject.Find("GameObjs").transform);    
     을 사용하여 GameObjs를 찾아 그의 하위에서 생성하는 것으로 해결하였다.    

2023-02-02 Animaion Ok, Mobile Btn Ok    
2023-02-03 Build v1.0.0    
2023-02-03 Update Font, Sound v1.0.1
