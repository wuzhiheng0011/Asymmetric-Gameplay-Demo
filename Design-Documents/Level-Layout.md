## 🗺️ 关卡布局设计

```mermaid
flowchart TB
    subgraph 起始区域
        A[紧闭的大门] -->|重型交互| B(蓄力攻击破门)
        A -->|轻型交互| C(攀爬倒塌石柱)
    end

    subgraph 主厅
        B --> D{重型路线}
        D --> E[地面战斗区] -->|击败近战兵| G
        C --> F{轻型路线}
        F --> H[房梁潜行] -->|躲避弓箭手| G
    end

    subgraph 最终区域
        G[BOSS战区域] --> I[双角色协作机制]
    end
