using UnityEngine; 

using UnityEngine.AI; 

 

public class AIController : MonoBehaviour 

{ 

    public float detectionRange = 10f; // ระยะการตรวจจับผู้เล่น 

    public float attackRange = 1.5f; // ระยะการโจมตี 

    public int damage = 10; // ความเสียหายที่โจมตี 

    public float attackRate = 1f; // ความถี่ในการโจมตี 

    public AudioClip runSound; // เสียงเมื่อมอนวิ่ง 

    public Animator animator; // ตัวแปรสำหรับ Animator 

 

    private NavMeshAgent agent; // ตัวแปรสำหรับ NavMesh Agent 

    private float nextAttackTime = 0f; // เวลาถัดไปที่จะโจมตี 

    private AudioSource audioSource; // ตัวแปรสำหรับ AudioSource 

    private Transform player; // อ้างอิงตำแหน่งของผู้เล่น 

 

    void Start() 

    { 

        agent = GetComponent<NavMeshAgent>(); // หา NavMesh Agent 

        audioSource = GetComponent<AudioSource>(); // หา AudioSource 

 

        // ค้นหาผู้เล่นที่มีแท็ก "Player" 

        player = GameObject.FindGameObjectWithTag("Player").transform; 

    } 

 

 

    void Update() 

    { 

        if (player != null) // ตรวจสอบว่าพบผู้เล่นหรือไม่ 

        { 

            float distanceToPlayer = Vector3.Distance(transform.position, player.position); 

 

            if (distanceToPlayer < detectionRange) 

            { 

                // เคลื่อนที่ไปหาผู้เล่น 

                agent.SetDestination(player.position); 

 

                // หันหน้าไปที่ผู้เล่น 

                Vector3 direction = player.position - transform.position; // คำนวณทิศทาง 

                direction.y = 0; // ยังคงตั้งค่า Y เป็น 0 เพื่อห้ามหมุนในแกน Y 

                if (direction != Vector3.zero) 

                { 

                    Quaternion targetRotation = Quaternion.LookRotation(direction); // คำนวณการหมุน 

                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f); // หมุนแบบ Smooth 

 

                    // เพิ่มการปรับแกนที่หมุน 

                    transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0); // ล็อคเฉพาะการหมุนในแกน Y 

                } 

 

                // เล่นเสียงวิ่งเมื่อ AI เคลื่อนที่ 

                if (!audioSource.isPlaying) 

                { 

                    audioSource.clip = runSound; // กำหนดเสียงวิ่ง 

                    audioSource.loop = true; // ตั้งค่าให้เล่นวน 

                    audioSource.Play(); // เล่นเสียงวิ่ง 

                } 

 

                // เช็คว่าอยู่ในระยะโจมตี 

                if (distanceToPlayer <= attackRange) 

                { 

                    Attack(); 

                } 

            } 

            else 

            { 

                agent.ResetPath(); // หยุดการเคลื่อนที่เมื่อไม่อยู่ในระยะ 

                audioSource.Stop(); // หยุดเสียงวิ่งเมื่อไม่อยู่ในระยะตรวจจับ 

            } 

        } 

    } 

 

    void Attack() 

    { 

        if (Time.time >= nextAttackTime) 

        { 

            nextAttackTime = Time.time + attackRate; // กำหนดเวลาโจมตีถัดไป 

 

            // เล่นอนิเมชั่นโจมตี 

            if (animator != null) 

            { 

                animator.SetTrigger("attack"); // ใช้ Trigger ที่ชื่อว่า "attack" 

            } 

 

            // ทำให้ผู้เล่นได้รับความเสียหาย 

            if (player.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth)) 

            { 

                playerHealth.TakeDamage(damage); 

            } 

        } 

    } 

 

    void OnDrawGizmos() 

    { 

        // วาด Gizmos เพื่อแสดงระยะตรวจจับ 

        Gizmos.color = Color.red; 

        Gizmos.DrawWireSphere(transform.position, detectionRange); 

 

        // วาด Gizmos ระยะโจมตี 

        Gizmos.color = Color.blue; 

        Gizmos.DrawWireSphere(transform.position, attackRange); 

    } 

} 