import { mount } from '@vue/test-utils'
import AtomLink from '../../atoms/AtomLink.vue'
import { describe, expect, test } from 'vitest'

describe(AtomLink, () => {
  const slotText = 'Text'
  const wrapper = mount(AtomLink, {
    slots: {
      default: slotText
    }
  })
  test('Render AtomLink', async () => {
    console.log(wrapper)
    expect(wrapper.exists()).toBe(true)
  })

  test('Slot is working', async () => {
    expect(wrapper.html()).toContain(slotText)
  })
})
