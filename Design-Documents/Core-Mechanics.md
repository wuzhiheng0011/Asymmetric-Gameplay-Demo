# 🎮 核心机制设计

## 角色系统

### 差异化能力对比
| **属性**         | **轻型角色**                | **重型角色**                  |
|------------------|----------------------------|-----------------------------|
| **移动能力**     | 二段跳                     | 蓄力重攻击（可破坏障碍物）    |
| **速度**         | ⚡ 移动速度快               | 🐢 移动速度慢                |
| **生存能力**     | ❤️ 脆弱（低生命值）         | 🛡️ 高生命值                 |

---

## 关键交互设计

### 进入教堂方式
```python
# 伪代码示例：角色进入逻辑
if 角色 == 轻型:
    通过二段跳 + 石柱攀至房梁
elif 角色 == 重型:
    蓄力攻击破坏大门
```

### 敌人应对策略
- **轻型角色优势目标**：  
  🎯 房梁弓箭手（需快速接近）  
- **重型角色优势目标**：  
  🛡️ 大厅近战兵（需正面对抗）  

---

## 设计意图
```diff
+ 强调非对称玩法：同一空间下，不同角色体验完全独立但互补
+ 通过角色能力限制自然引导玩家探索路径
```

> 📌 **预想**：数值需在测试阶段平衡（如弓箭手攻击频率/近战兵伤害值）。
>## 🔑 关键交互设计

### 🚨 设计亮点
> 🔥 **核心创新点**：  
> **不同角色差异化的关卡路线**，双角色的关卡视野与空间互通但却物理阻隔。  
> - 重型角色在地面**依然会受到弓箭手攻击**（强制策略选择）  
> - 轻型角色被**地形限制**（坠落即死风险）  

### ⛪ 进入教堂方式
| **角色类型** | **交互方式**                     | **风险/限制**          |
|--------------|----------------------------------|------------------------|
| 轻型角色     | `二段跳` + 攀爬石柱至房梁        | 坠落死亡（无坠落保护） |
| 重型角色     | `蓄力攻击`破坏大门               | 暴露在弓箭手射程内     |

```mermaid
graph LR
    A[共享视野] --> B[物理隔离]
    B --> C[轻型: 高空路线]
    B --> D[重型: 地面路线]
    C -.->|坠落风险| E[死亡]
    D -.->|弓箭伤害| F[策略躲避]
