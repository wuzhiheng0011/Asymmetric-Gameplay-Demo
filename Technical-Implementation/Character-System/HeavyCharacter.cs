
using UnityEngine;

public class PlayerHeavy : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public int maxJumps = 1;

    [Header("攻击设置")]
    public float normalAttackDamage = 10f;        // 普通攻击伤害
    public float chargedAttackDamage = 30f;       // 蓄力攻击伤害
    public float chargeTime = 1.5f;               // 最小蓄力时间
    public float attackRange = 2f;                // 攻击范围
    public LayerMask attackableLayers;            // 可攻击层级
    public GameObject attackEffect;               // 攻击特效

    private Rigidbody rb;
    private int jumpsLeft;
    private float chargeTimer;
    private bool isCharging;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jumpsLeft = maxJumps;
    }

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleAttack();
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        rb.velocity = new Vector3(moveX * moveSpeed, rb.velocity.y, moveZ * moveSpeed);
    }

    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && jumpsLeft > 0)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpsLeft--;
        }
    }

    void HandleAttack()
    {
        // 开始蓄力
        if (Input.GetKeyDown(KeyCode.J))
        {
            isCharging = true;
            chargeTimer = 0f;
        }

        // 蓄力中
        if (isCharging && Input.GetKey(KeyCode.J))
        {
            chargeTimer += Time.deltaTime;
            // 这里可以添加蓄力特效或UI提示
        }

        // 释放攻击
        if (isCharging && Input.GetKeyUp(KeyCode.J))
        {
            if (chargeTimer >= chargeTime)
            {
                PerformAttack(true); // 蓄力攻击
            }
            else
            {
                PerformAttack(false); // 普通攻击
            }
            isCharging = false;
        }
    }

    void PerformAttack(bool isChargedAttack)
    {
        // 播放攻击特效
        if (attackEffect != null)
        {
            Instantiate(attackEffect, transform.position + transform.forward, Quaternion.identity);
        }

        // 检测攻击范围内的敌人
        Collider[] hitEnemies = Physics.OverlapSphere(transform.position + transform.forward, attackRange, attackableLayers);

        foreach (Collider enemy in hitEnemies)
        {
            // 这里假设敌人有Health组件
            Health enemyHealth = enemy.GetComponent<Health>();
            if (enemyHealth != null)
            {
                float damage = isChargedAttack ? chargedAttackDamage : normalAttackDamage;
                enemyHealth.TakeDamage(damage);

                // 击退效果
                if (enemy.GetComponent<Rigidbody>() != null)
                {
                    Vector3 direction = (enemy.transform.position - transform.position).normalized;
                    enemy.GetComponent<Rigidbody>().AddForce(direction * damage, ForceMode.Impulse);
                }
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            jumpsLeft = maxJumps;
    }

    // 可视化攻击范围（仅在编辑器中可见）
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.forward, attackRange);
    }
}
