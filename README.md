# 🎮 双角色教堂潜入 Demo 设计文档


## 🕹️ 核心机制设计

### 角色系统
| **属性**         | **轻型角色**                | **重型角色**                  |
|------------------|----------------------------|-----------------------------|
| **移动能力**     | 二段跳                     | 蓄力重攻击（可破坏障碍物）    |
| **速度**         | ⚡ 移动速度快               | 🐢 移动速度慢                |
| **生存能力**     | ❤️ 脆弱（低生命值）         | 🛡️ 高生命值                 |

## 角色能力分布（数值对比）

**轻型角色属性分配：**
- 敏捷性：■■■■■■■ (70/100)
- 力量：■■■ (30/100)

**重型角色属性分配：**
- 敏捷性：■■■ (20/100)
- 力量：■■■■■■■■ (80/100)
## 关键交互设计

### 核心创新亮点
1. **差异化路线机制**
   - 双角色共享全局视野但物理路径隔离
   - 轻型角色专属高空路线（房梁）
   - 重型角色专属地面路线（大厅）
<div align="center">
  <img src="./Art-References/屏幕截图 2025-04-03 134954.png" width="600" alt="初步白模设计">
  <br>
  <sup>Unity 2021 LTS | PC 平台 | 非对称玩法原型</sup>
</div>
<div align="center">
  <img src="./Art-References/屏幕截图 2025-04-03 140307.png" width="600" alt="场地概念图">
  <br>
  <sup>Unity 2021 LTS | PC 平台 | 非对称玩法原型</sup>
</div>
2. **风险平衡设计**
   - ▶️ 重型角色劣势：持续暴露于弓箭手火力范围
   - ▶️ 轻型角色劣势：狭窄通道+坠落即死惩罚

### 交互方式对比表
| 角色类型 | 进入方式                 | 核心风险               | 应对策略               |
|----------|--------------------------|------------------------|------------------------|
| 轻型     | 二段跳+石柱攀爬→房梁    | 高空坠落死亡           | 坠落前0.5秒缓速效果    |
| 重型     | 蓄力攻击破门→大厅       | 弓箭手集火攻击         | 可拾取临时盾牌道具     |
## 🧭 引导设计系统

### ✨ 视觉引导方案
#### 1. 角色能力暗示
| **引导元素**       | **设计实现**                              | **目标效果**                     |
|--------------------|------------------------------------------|----------------------------------|
| 告示牌（悬赏飞贼） |        悬赏飞贼                                  | 玩家联想「飞贼→敏捷→轻型角色优势」 |
| 木制大门           | 轻攻击击打时内部敌人发出嘲讽                        | 联想到重攻击           |

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
        G[BOSS战区域] --> I[双角色可体验到同一boss的不同机制]
    end




