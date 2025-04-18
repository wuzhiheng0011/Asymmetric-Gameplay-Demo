## 🧭 引导设计系统

### ✨ 视觉引导方案
#### 1. 角色能力暗示
| **引导元素**       | **设计实现**                              | **目标效果**                     |
|--------------------|------------------------------------------|----------------------------------|
| 告示牌（悬赏飞贼） | ![](https://via.placeholder.com/150x50?text=Wanted+Poster) | 玩家联想「飞贼→敏捷→轻型角色优势」 |
| 破损石柱           | 添加`可攀爬发光材质` (Shader: `Fresnel`) | 自然吸引轻型角色注意力           |

```mermaid
graph LR
    A[玩家看到告示牌] --> B{认知关联}
    B -->|飞贼画像+轻甲| C[选择轻型角色]
    B -->|破损大门+重武器| D[选择重型角色]
