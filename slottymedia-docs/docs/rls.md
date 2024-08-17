# 🌟 Role Level Security (RLS) Documentation

## 📋 Overview
Role Level Security (RLS) helps control access to your database tables based on user roles. Here's a quick guide to the RLS policies applied to our tables.

---

## 🛠️ General Policies

- **🗑️ DELETE:** User-based, for authenticated users
- **➕ INSERT:** Authenticated users only
- **🔍 SELECT:** Public access
- **✏️ UPDATE:** User-based, for authenticated users

---

## 📂 Table-Specific Policies

### 📝 Comment
- **RLS:** Enabled
- **🗑️ DELETE:** Authenticated users
- **➕ INSERT:** Authenticated users
- **🔍 SELECT:** Public
- **✏️ UPDATE:** Authenticated users

### 👥 Follower_User_Relation
- **RLS:** Enabled
- **🗑️ DELETE:** Authenticated users
- **➕ INSERT:** Authenticated users
- **🔍 SELECT:** Public
- **✏️ UPDATE:** Authenticated users

### 📢 Forum
- **RLS:** Enabled
- **🗑️ DELETE:** Authenticated users
- **➕ INSERT:** Authenticated users
- **🔍 SELECT:** Public
- **✏️ UPDATE:** Authenticated users

### 🗂️ Posts
- **RLS:** Enabled
- **🗑️ DELETE:** Authenticated users
- **➕ INSERT:** Authenticated users
- **🔍 SELECT:** Public
- **✏️ UPDATE:** Authenticated users

### 🛠️ Role
- **RLS:** Enabled
- **➕ INSERT:** Authenticated users
- **🔍 SELECT:** Public

### 👤 User
- **RLS:** Enabled
- **🗑️ DELETE:** Authenticated users
- **➕ INSERT:** Authenticated users
- **🔍 SELECT:** Public
- **✏️ UPDATE:** Public

### ❤️ User_Like_Post_Relation
- **RLS:** Enabled
- **🗑️ DELETE:** Public
- **➕ INSERT:** Authenticated users
- **🔍 SELECT:** Public
- **✏️ UPDATE:** Authenticated users


