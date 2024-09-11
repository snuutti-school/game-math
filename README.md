# Exercise 1

### Definition:

* **Attach** (or *soft parenting*): means attached object moves and rotate relative to another object space. In Unity terms, the attached object behaves as if its transform was parented to another object's transform (parent)
* **Clockwise** and **Counter Clockwise**: rotations around world Y axis with world Z axis as 12:00 hourhand

| Grade | Mechanics |
| :---: | ------------- |
| 1 | `Crane` is able to rotate around world Y axis and has `Trolley` attached to it |
| 2 | `Cable` is attached to `Trolley` and `Hook` is attached to `Cable` |
| 3 | `Trolley` linear motion is restricted within line segment connected 2 points on `Crane`'s arm |
| 4 | `Cable` length can change to lift or lower `Hook`, but must be limited: lift only upto the `Trolley` and cannot lower infinitely |
| 5 | `Hook` attaches to `Concrete` when collides with `Concrete`'s attachment point |

### Note:
* `Transform` parenting is not allowed
* `ParentConstraint` component is not allowed
* No physics simulation is required in this exercise
* `Crane`, `Trolley` and `Cable` control must comply to provided UI template (explained in other section)
* Collsion checking between `Hook` and `Concrete`'s attachment point can be achieve by rigidbody collision, rigidbody trigger zone, distance checking or by any other creative methods
* `Cable` mechanics can be done with `LineRenderer` component or provided cable model

### UI Control
* `Left button` rotates `Crane` clockwise
* `Right button` rotates `Crane` counter clockwise
* `Trolley slider` controls normalized position of `Trolley` along segment created by near point and far point on `Crane`'s arm
* `Cable slider` controls `Cable` normalized length from min length to max length 