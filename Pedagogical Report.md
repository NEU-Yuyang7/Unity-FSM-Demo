# Pedagogical Report

# **1. Teaching Philosophy**

### **Target Audience**

This teaching module is designed for **beginner to intermediate Unity students** who have basic programming knowledge (C# syntax, Unity components) but limited exposure to **game AI systems**. The goal is to introduce a foundational AI concept—Finite State Machines (FSMs)—through a practical and highly approachable implementation.

### **Learning Objectives**

By the end of the lesson, students should be able to:

1. Understand the concept of a Finite State Machine and why it is widely used in games.
2. Identify states, transitions, and conditions in AI behavior.
3. Implement a working FSM enemy in Unity using C#.
4. Visualize and debug AI behavior logically.
5. Extend the FSM with new states and transitions.

### **Pedagogical Rationale**

FSMs provide an ideal entry point to game AI because:

- They are **simple, visual, interpretable**, and demonstrate clear cause-effect behavior.
- They map naturally to gameplay scenarios (Idle → Patrol → Chase).
- They help students build **mental models** for more advanced techniques (Behavior Trees, Utility AI, GOAP).
- The structure is modular and testable, producing immediate visual feedback—important for experiential learning.

The instructional approach follows **Explain → Show → Try**, supporting incremental learning:

1. **Explain:** Introduce AI concepts and motivation.
2. **Show:** Demonstrate each state in Unity with real code.
3. **Try:** Let students apply changes, observe behavior, and debug.

This aligns with active learning principles and scaffolding for novice programmers.

------

# **2. Concept Deep Dive**

### **2.1 What Is a Finite State Machine?**

A Finite State Machine (FSM) is a computational model consisting of:

- A **finite set of states** (Idle, Patrol, Chase)
- A **current active state**
- A set of **transition rules** that determine when to switch states
- **Triggers/conditions** that cause transitions

Formally:

- $S = \{s_1, s_2, ..., s_n\}$
- $s_0 \in S$ is the initial state
- $T : S \times Inputs \rightarrow S$ is the transition function

FSMs are deterministic: the same input always results in the same transition.

### **2.2 FSMs in Game AI**

FSMs are one of the oldest yet still most effective AI systems used in games. They are used in:

- Enemy AI behavior
- NPC interaction
- Combat systems
- Boss stage transitions
- Player movement / animation graphs

FSMs excel in scenarios requiring:

- Clear, well-defined states
- Predictable transitions
- Limited complexity

### **2.3 FSM for Enemy AI**

The teaching demo implements a **three-state FSM**:

------

### **Idle → Patrol → Chase**

#### **Idle State**

The AI waits, observing whether the player appears.
 Transition conditions:

- Player detected → Chase
- Idle timer exceeded → Patrol

#### **Patrol State**

The AI walks along predefined waypoints.
 Transition conditions:

- Player detected → Chase
- Patrol point reached → move to next waypoint

#### **Chase State**

The AI moves toward the player aggressively.
 Transition conditions:

- Player escapes range → Idle
- Player gets very close → (Attack if included)

------

### **Why FSM Works Well for This Project**

- States are fully isolated, making logic easy to read.
- Transitions are intuitive and visually observable.
- Students immediately understand AI decision-making.
- The system is extendable (Add Flee, Investigate, Attack).

FSMs allow students to develop **algorithmic thinking** without being overwhelmed by complexity.

------

# **3. Implementation Analysis**

### **3.1 System Architecture**

The implementation uses a **switch-based FSM** inside Unity:

```
Update():
    switch(currentState)
        case Idle: IdleUpdate()
        case Patrol: PatrolUpdate()
        case Chase: ChaseUpdate()
```

Core components:

| Component             | Responsibility                     |
| --------------------- | ---------------------------------- |
| **EnemyState Enum**   | Defines state machine states       |
| **ChangeState()**     | Handles entering new states        |
| **IdleUpdate()**      | Waits until timer/player detection |
| **PatrolUpdate()**    | Moves between waypoints            |
| **ChaseUpdate()**     | Actively pursues the player        |
| **IsPlayerInSight()** | Detection logic                    |
| **MoveTowards()**     | Movement utility                   |

This decomposition ensures:

- High readability
- Clean separation of logic
- Easy debugging
- Strong pedagogical clarity

### **3.2 Performance Considerations**

FSMs are extremely lightweight:

- Constant-time state checks
- Minimal memory overhead
- No dynamic allocation

Even 1,000+ FSM-driven enemies would run smoothly.

Unity-specific optimizations:

- Avoid using `GetComponent()` in Update
- Avoid expensive physics checks in every frame
- Separate detection radius from vision cones for simplicity

### **3.3 Scalability & Extensibility**

FSMs scale well **vertically** (more states) but poorly **horizontally** (complex transitions).
 Students learn the limitations:

Where FSM works:

- Patrol → Chase → Attack
- Linear or branching behavior

Where FSM breaks down:

- Dozens of states
- Highly dynamic systems
- Situations requiring prioritization or scoring

This naturally leads students to explore:

- Behavior Trees
- Utility AI
- GOAP (Goal-Oriented Action Planning)

FSM is the perfect gateway to advanced AI systems.

------

# **4. Assessment & Effectiveness**

### **4.1 Student Assessment Criteria**

Students are evaluated based on:

#### ✔ Understanding of state transitions

Can they explain why a transition occurs?

#### ✔ Ability to modify or extend behavior

e.g., adding a "Flee" or "Search" state.

#### ✔ Debugging capability

Can they identify bugs like unreachable states or incorrect conditions?

#### ✔ Code readability and structure

Is the FSM correctly modularized and commented?

### **4.2 Common Student Challenges**

| Problem                   | Explanation                |
| ------------------------- | -------------------------- |
| Missing transitions       | AI gets stuck in a state   |
| Incorrect detection logic | Chase never triggers       |
| Frame-based logic issues  | Overusing `Time.deltaTime` |
| Movement jitter           | Incorrect normalization    |

These challenges guide teaching scaffolding.

### **4.3 Effectiveness of this Teaching Model**

Students benefit strongly from this approach because:

- The AI behavior is **visually obvious**
- The logic is **conceptually simple**
- FSM structure maps well to real-world enemy AI
- Debugging encourages deeper understanding

Hands-on practice reinforces theoretical learning, producing a highly effective pedagogy for game AI fundamentals.

