# 🎮 双角色教堂潜入 Demo 设计文档

<div align="center">
  <img src="https://via.placeholder.com/800x400?text=Gameplay+Screenshot" width="600" alt="游戏概念图">
  <br>
  <sup>Unity 2021 LTS | PC 平台 | 非对称玩法原型</sup>
</div>

---

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
   - 轻型角色专属高空路线（房梁系统）
   - 重型角色专属地面路线（可破坏场景）

2. **风险平衡设计**
   - ▶️ 重型角色劣势：持续暴露于弓箭手火力范围
   - ▶️ 轻型角色劣势：狭窄通道+坠落即死惩罚

### 交互方式对比表
| 角色类型 | 进入方式                 | 核心风险               | 应对策略               |
|----------|--------------------------|------------------------|------------------------|
| 轻型     | 二段跳+石柱攀爬→房梁    | 高空坠落死亡           | 坠落前0.5秒缓速效果    |
| 重型     | 蓄力攻击破门→大厅       | 弓箭手集火攻击         | 可拾取临时盾牌道具     |

实现要点 🛠️
物理隔离系统 🏗️

⚙️ 使用Unity的LayerCollision矩阵控制

☠️ 高空路线设置死亡区触发器

视觉反馈 👀

💥 重型角色受击时屏幕边缘泛红

🌪️ 轻型角色坠落前镜头震动预警


sequenceDiagram  
    轻型角色--🐒-->房梁: 跳跃攀爬  
    重型角色--💢-->大门: 蓄力攻击  
    弓箭手--🏹-->>重型角色: 持续射击  
关卡布局设计 🗺️
区域路线说明 🚧
起始区域：

🏋️‍♂️ 重型路线：大门 → 破门进入 (需蓄力攻击)

🐒 轻型路线：大门 → 攀爬石柱进入

主厅区域：

路线类型	路径详情	主要挑战
🏋️‍♂️ 重型路线	地面战斗区	近战兵×3 (仇恨范围5m)
🦸‍♂️ 轻型路线	高空房梁 (宽度1.2m)	平衡跳跃+弓箭手🏹
最终区域：

🔥 触发条件：双角色同时到达

🐉 BOSS机制：根据角色类型激活不同阶段

引导系统设计 🧭
视觉引导方案 👁️
引导元素	实现方式	验证效果
🏍 悬赏飞贼告示牌	轻甲图标+动态高亮✨	85%玩家首选轻型角色📊
🚪 大门裂痕	随接近距离增强裂纹效果💢	破门尝试率提升40%📈
